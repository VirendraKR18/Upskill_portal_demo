using System;
using API.Models;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace API.Tests
{
    public class JwtTokenServiceTests
    {
        private readonly JwtTokenService _service;

        public JwtTokenServiceTests()
        {
            var inMemorySettings = new System.Collections.Generic.Dictionary<string, string> {
                {"JWT:SecretKey", "test-secret-key-which-is-long-enough"},
                {"JWT:Issuer", "test-issuer"},
                {"JWT:Audience", "test-audience"},
                {"JWT:ExpirationMinutes", "480"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var logger = new Mock<ILogger<JwtTokenService>>().Object;
            _service = new JwtTokenService(configuration, logger);
        }

        [Fact]
        public void GenerateJwtToken_Includes_Claims_And_Has_Expiry()
        {
            var sso = new SSOClaimsDto
            {
                EmployeeId = "E1000",
                Email = "user@contoso.com",
                Name = "Test User",
                Roles = new System.Collections.Generic.List<string> { "AAD_Group_Managers" }
            };

            var token = _service.GenerateJwtToken(sso, "Manager", out var expiresAt);
            Assert.False(string.IsNullOrWhiteSpace(token));
            Assert.True(expiresAt > DateTime.UtcNow.AddHours(7)); // close to 8 hours
        }

        [Fact]
        public void GenerateRefreshToken_Is_Not_Empty_And_Base64()
        {
            var refresh = _service.GenerateRefreshToken();
            Assert.False(string.IsNullOrWhiteSpace(refresh));
            // Should be valid base64
            Convert.FromBase64String(refresh);
        }

        [Fact]
        public void ValidateToken_Returns_Principal_For_Valid_Token()
        {
            var sso = new SSOClaimsDto
            {
                EmployeeId = "E1001",
                Email = "user2@contoso.com",
                Name = "User Two"
            };

            var token = _service.GenerateJwtToken(sso, "Learner", out var expiresAt);
            var principal = _service.ValidateToken(token);
            Assert.NotNull(principal);
            Assert.Equal("Learner", principal.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value);
            Assert.Equal("user2@contoso.com", principal.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value);
        }
    }
}