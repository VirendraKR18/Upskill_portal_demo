using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using API.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISSOService _ssoService;
        private readonly IRoleMappingService _roleMapping;
        private readonly IJwtTokenService _jwtService;
        private readonly IUserRepository _userRepo;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ISSOService ssoService,
            IRoleMappingService roleMapping,
            IJwtTokenService jwtService,
            IUserRepository userRepo,
            ILogger<AuthController> logger)
        {
            _ssoService = ssoService;
            _roleMapping = roleMapping;
            _jwtService = jwtService;
            _userRepo = userRepo;
            _logger = logger;
        }

        [HttpPost("callback")]
        public async Task<IActionResult> Callback([FromBody] SSOCallbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid request." });
            }

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            try
            {
                // Exchange authorization code for tokens
                var tokenResp = await _ssoService.ExchangeAuthorizationCodeAsync(request.Code, request.RedirectUri);

                // Validate the id_token (preferred). If absent, validate access_token.
                var idToken = string.IsNullOrWhiteSpace(tokenResp.IdToken) ? tokenResp.AccessToken : tokenResp.IdToken;
                var claims = await _ssoService.ValidateSSOTokenAsync(idToken);

                // Security: ensure employee id present
                if (string.IsNullOrWhiteSpace(claims.EmployeeId))
                {
                    _logger.LogWarning("Authentication attempt without employee ID from IP {IP}", ip);
                    await _userRepo.LogAuthEventAsync(new AuthLogEntry
                    {
                        EmployeeId = null,
                        IpAddress = ip,
                        TimestampUtc = DateTime.UtcNow,
                        EventType = "AuthFailed:NoEmployeeId",
                        Severity = "Medium",
                        Details = "Employee ID missing from SSO claims"
                    });
                    return Unauthorized(new { message = "Authentication failed. Please try again." });
                }

                // User provisioning check
                var user = await _userRepo.GetByEmployeeIdAsync(claims.EmployeeId!);
                if (user == null)
                {
                    await _userRepo.LogAuthEventAsync(new AuthLogEntry
                    {
                        EmployeeId = claims.EmployeeId,
                        IpAddress = ip,
                        TimestampUtc = DateTime.UtcNow,
                        EventType = "AuthFailed:AccountNotProvisioned",
                        Severity = "Medium",
                        Details = "Employee not found in Users table"
                    });

                    return Unauthorized(new { message = "Account not provisioned. Your employee record will be synced from Workday within 4 hours. Please try again later." });
                }

                if (!user.IsActive)
                {
                    await _userRepo.LogAuthEventAsync(new AuthLogEntry
                    {
                        UserId = user.Id,
                        EmployeeId = claims.EmployeeId,
                        IpAddress = ip,
                        TimestampUtc = DateTime.UtcNow,
                        EventType = "AuthFailed:AccountDeactivated",
                        Severity = "Medium",
                        Details = "User account deactivated"
                    });

                    return Unauthorized(new { message = "Account deactivated. Please contact IT support." });
                }

                // Role mapping
                var platformRole = _roleMapping.MapSSORoleToAppRole(claims.Roles, claims.Email);

                // Generate JWT
                var jwt = _jwtService.GenerateJwtToken(claims, platformRole, out var expiresAtUtc);

                // Generate refresh token & persist session
                var refreshToken = _jwtService.GenerateRefreshToken();
                var tokenId = Guid.NewGuid().ToString(); // token id for session store

                var session = new UserSessionEntity
                {
                    UserId = user.Id,
                    TokenId = tokenId,
                    IssuedAt = DateTime.UtcNow,
                    ExpiresAt = expiresAtUtc,
                    RefreshToken = refreshToken
                };
                await _userRepo.StoreSessionAsync(session);

                await _userRepo.LogAuthEventAsync(new AuthLogEntry
                {
                    UserId = user.Id,
                    EmployeeId = claims.EmployeeId,
                    IpAddress = ip,
                    TimestampUtc = DateTime.UtcNow,
                    EventType = "AuthSuccess",
                    Severity = "Info",
                    Details = $"Role:{platformRole}"
                });

                var response = new AuthResponseDto
                {
                    AccessToken = jwt,
                    RefreshToken = refreshToken,
                    ExpiresInMinutes = (int)(expiresAtUtc - DateTime.UtcNow).TotalMinutes,
                    Role = platformRole,
                    RedirectUrl = "/individual/dashboard"
                };

                return Ok(response);
            }
            catch (UnauthorizedAccessException uaex)
            {
                _logger.LogWarning(uaex, "Authentication failed from IP {IP}", ip);
                await _userRepo.LogAuthEventAsync(new AuthLogEntry
                {
                    EmployeeId = null,
                    IpAddress = ip,
                    TimestampUtc = DateTime.UtcNow,
                    EventType = "AuthFailed:InvalidToken",
                    Severity = "High",
                    Details = uaex.Message
                });
                return Unauthorized(new { message = "Authentication failed. Please try again." });
            }
            catch (InvalidOperationException ioe)
            {
                _logger.LogWarning(ioe, "SSO provider error from IP {IP}", ip);
                await _userRepo.LogAuthEventAsync(new AuthLogEntry
                {
                    EmployeeId = null,
                    IpAddress = ip,
                    TimestampUtc = DateTime.UtcNow,
                    EventType = "AuthFailed:ProviderError",
                    Severity = "Medium",
                    Details = ioe.Message
                });
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, new { message = "Authentication service temporarily unavailable. Please try again in a few minutes." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected authentication error from IP {IP}", ip);
                await _userRepo.LogAuthEventAsync(new AuthLogEntry
                {
                    EmployeeId = null,
                    IpAddress = ip,
                    TimestampUtc = DateTime.UtcNow,
                    EventType = "AuthFailed:Unexpected",
                    Severity = "High",
                    Details = ex.Message
                });
                // Do not leak internal error details
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An unexpected error occurred. Please contact support." });
            }
        }

        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrWhiteSpace(userIdClaim))
            {
                return Unauthorized();
            }

            // userId stored as EmployeeId or GUID; try GUID parse first
            if (Guid.TryParse(userIdClaim, out var guid))
            {
                var user = await _userRepo.GetByIdAsync(guid);
                if (user == null) return NotFound();
                return Ok(new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    Role = user.Role,
                    AvatarUrl = user.AvatarUrl
                });
            }
            else
            {
                // fallback: find by employee id
                var user = await _userRepo.GetByEmployeeIdAsync(userIdClaim);
                if (user == null) return NotFound();
                return Ok(new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    Role = user.Role,
                    AvatarUrl = user.AvatarUrl
                });
            }
        }
    }
}