using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public interface ISSOService
    {
        Task<SSOClaimsDto> ValidateSSOTokenAsync(string idToken);
        Task<TokenResponse> ExchangeAuthorizationCodeAsync(string code, string redirectUri);
    }

    public record TokenResponse(string AccessToken, string IdToken, int ExpiresIn, string? RefreshToken);

    public class SSOService : ISSOService
    {
        private readonly ILogger<SSOService> _logger;
        private readonly IConfiguration _config;
        private readonly IConfigurationManager<OpenIdConnectConfiguration> _configurationManager;
        private readonly string _instance;
        private readonly string _tenantId;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public SSOService(IConfiguration config, ILogger<SSOService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));

            _instance = _config["Authentication:AzureAd:Instance"]?.TrimEnd('/') ?? throw new ArgumentException("AzureAd.Instance not configured");
            _tenantId = _config["Authentication:AzureAd:TenantId"] ?? throw new ArgumentException("AzureAd.TenantId not configured");
            _clientId = _config["Authentication:AzureAd:ClientId"] ?? throw new ArgumentException("AzureAd.ClientId not configured");
            _clientSecret = _config["Authentication:AzureAd:ClientSecret"] ?? string.Empty; // allow empty in test env

            var wellKnown = $"{_instance}/{_tenantId}/v2.0/.well-known/openid-configuration";
            var documentRetriever = new HttpDocumentRetriever { RequireHttps = true };
            _configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(wellKnown, new OpenIdConnectConfigurationRetriever(), documentRetriever);
        }

        public async Task<TokenResponse> ExchangeAuthorizationCodeAsync(string code, string redirectUri)
        {
            // Exchange auth code for tokens using token endpoint from metadata
            var config = await _configurationManager.GetConfigurationAsync();
            var tokenEndpoint = config.TokenEndpoint ?? throw new InvalidOperationException("Token endpoint not found in metadata");

            using var http = new HttpClient();
            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["code"] = code,
                ["redirect_uri"] = redirectUri,
                ["client_id"] = _clientId
            };

            // Client secret only if configured (production uses KeyVault)
            if (!string.IsNullOrWhiteSpace(_clientSecret))
            {
                form["client_secret"] = _clientSecret;
            }

            var resp = await http.PostAsync(tokenEndpoint, new FormUrlEncodedContent(form));
            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogWarning("Token endpoint returned non-success status {Status} when exchanging code", resp.StatusCode);
                throw new InvalidOperationException("Authentication service returned an error.");
            }

            var payload = await resp.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            if (payload == null) throw new InvalidOperationException("Invalid token response from provider.");

            payload.TryGetValue("access_token", out var accessObj);
            payload.TryGetValue("id_token", out var idObj);
            payload.TryGetValue("expires_in", out var expiresObj);
            payload.TryGetValue("refresh_token", out var refreshObj);

            var accessToken = accessObj?.ToString() ?? string.Empty;
            var idToken = idObj?.ToString() ?? string.Empty;
            var expires = expiresObj != null && int.TryParse(expiresObj.ToString(), out var e) ? e : 0;
            var refreshToken = refreshObj?.ToString();

            return new TokenResponse(accessToken, idToken, expires, refreshToken);
        }

        public async Task<SSOClaimsDto> ValidateSSOTokenAsync(string idToken)
        {
            if (string.IsNullOrWhiteSpace(idToken)) throw new ArgumentException("idToken is required");

            var config = await _configurationManager.GetConfigurationAsync();
            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer = config.Issuer,
                ValidateIssuer = true,
                ValidAudiences = new[] { _clientId },
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.FromSeconds(60),
                IssuerSigningKeys = config.SigningKeys
            };

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var principal = handler.ValidateToken(idToken, validationParameters, out var validatedToken);
                var jwt = validatedToken as JwtSecurityToken;
                var claims = principal.Claims.ToList();

                var dto = new SSOClaimsDto
                {
                    Subject = principal.FindFirstValue("sub") ?? principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty,
                    Issuer = jwt?.Issuer ?? config.Issuer ?? string.Empty,
                    Email = principal.FindFirstValue(ClaimTypes.Email) ?? principal.FindFirstValue("email") ?? string.Empty,
                    Name = principal.FindFirstValue(ClaimTypes.Name) ?? principal.FindFirstValue("name") ?? string.Empty,
                    EmployeeId = principal.FindFirstValue("employeeId") ?? principal.FindFirstValue("employee_id"), // custom claim variations
                    Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).Concat(principal.FindAll("roles").Select(c => c.Value)).Distinct().ToList(),
                    RawClaims = jwt?.Payload as IDictionary<string, object>
                };

                return dto;
            }
            catch (SecurityTokenSignatureKeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Token signature keys not found or JWKS out of date.");
                throw new UnauthorizedAccessException("Invalid token signature.");
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogWarning(ex, "Token validation failed.");
                throw new UnauthorizedAccessException("Token validation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error validating SSO token.");
                throw;
            }
        }
    }
}