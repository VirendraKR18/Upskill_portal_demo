using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(SSOClaimsDto claims, string platformRole, out DateTime expiresAtUtc);
        string GenerateRefreshToken();
        ClaimsPrincipal? ValidateToken(string token, bool validateLifetime = true);
    }

    public class JwtTokenService : IJwtTokenService
    {
        private readonly ILogger<JwtTokenService> _logger;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationMinutes;
        private readonly byte[] _secretKeyBytes;

        public JwtTokenService(IConfiguration config, ILogger<JwtTokenService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _secretKey = config["JWT:SecretKey"] ?? throw new ArgumentException("JWT:SecretKey not configured");
            _issuer = config["JWT:Issuer"] ?? "upskill.local";
            _audience = config["JWT:Audience"] ?? "upskill.api";
            _expirationMinutes = int.TryParse(config["JWT:ExpirationMinutes"], out var m) ? m : 480;
            _secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);
        }

        public string GenerateJwtToken(SSOClaimsDto claims, string platformRole, out DateTime expiresAtUtc)
        {
            var now = DateTime.UtcNow;
            expiresAtUtc = now.AddMinutes(_expirationMinutes);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(_secretKeyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenId = Guid.NewGuid().ToString();

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim("jti", tokenId),
                new Claim("userId", claims.EmployeeId ?? claims.Subject ?? string.Empty),
                new Claim(ClaimTypes.Email, claims.Email ?? string.Empty),
                new Claim(ClaimTypes.Name, claims.Name ?? string.Empty),
                new Claim(ClaimTypes.Role, platformRole)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = _issuer,
                Audience = _audience,
                NotBefore = now,
                Expires = expiresAtUtc,
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            _logger.LogDebug("Generated JWT for user {UserId} with role {Role} expiring at {Expiry}", claims.EmployeeId, platformRole, expiresAtUtc);
            return jwt;
        }

        public string GenerateRefreshToken()
        {
            // 32 bytes -> Base64
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public ClaimsPrincipal? ValidateToken(string token, bool validateLifetime = true)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(_secretKeyBytes);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = !string.IsNullOrEmpty(_issuer),
                ValidIssuer = _issuer,
                ValidateAudience = !string.IsNullOrEmpty(_audience),
                ValidAudience = _audience,
                ValidateLifetime = validateLifetime,
                ClockSkew = TimeSpan.FromSeconds(60)
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "JWT validation failed.");
                return null;
            }
        }
    }
}