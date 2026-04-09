using System;
using System.Threading.Tasks;
using API.Controllers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace API.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<ISSOService> _ssoMock = new();
        private readonly Mock<IRoleMappingService> _roleMock = new();
        private readonly Mock<IJwtTokenService> _jwtMock = new();
        private readonly Mock<IUserRepository> _userRepoMock = new();
        private readonly Mock<ILogger<AuthController>> _loggerMock = new();

        private AuthController CreateController()
        {
            var controller = new AuthController(_ssoMock.Object, _roleMock.Object, _jwtMock.Object, _userRepoMock.Object, _loggerMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            return controller;
        }

        [Fact]
        public async Task Callback_Returns_Unauthorized_If_No_EmployeeId()
        {
            var request = new SSOCallbackRequest { Code = "c", RedirectUri = "https://app/redirect" };

            _ssoMock.Setup(s => s.ExchangeAuthorizationCodeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new TokenResponse("access", "", 3600, null));
            _ssoMock.Setup(s => s.ValidateSSOTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(new SSOClaimsDto { EmployeeId = null, Email = "a@b.com" });

            var controller = CreateController();
            var result = await controller.Callback(request);

            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public async Task Callback_Returns_401_If_User_Not_Provisioned()
        {
            var request = new SSOCallbackRequest { Code = "c", RedirectUri = "https://app/redirect" };

            _ssoMock.Setup(s => s.ExchangeAuthorizationCodeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new TokenResponse("access", "idtoken", 3600, null));
            _ssoMock.Setup(s => s.ValidateSSOTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(new SSOClaimsDto { EmployeeId = "E999", Email = "a@b.com" });

            _userRepoMock.Setup(r => r.GetByEmployeeIdAsync("E999")).ReturnsAsync((UserEntity?)null);

            var controller = CreateController();
            var result = await controller.Callback(request);

            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Contains("Account not provisioned", unauthorized.Value.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task Callback_Success_Returns_Tokens()
        {
            var request = new SSOCallbackRequest { Code = "c", RedirectUri = "https://app/redirect" };

            _ssoMock.Setup(s => s.ExchangeAuthorizationCodeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new TokenResponse("access", "idtoken", 3600, "rtoken"));
            var claims = new SSOClaimsDto
            {
                EmployeeId = "E12345",
                Email = "jane.doe@contoso.com",
                Name = "Jane"
            };
            _ssoMock.Setup(s => s.ValidateSSOTokenAsync(It.IsAny<string>())).ReturnsAsync(claims);

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                EmployeeId = "E12345",
                Email = "jane.doe@contoso.com",
                IsActive = true
            };
            _userRepoMock.Setup(r => r.GetByEmployeeIdAsync("E12345")).ReturnsAsync(user);
            _roleMock.Setup(r => r.MapSSORoleToAppRole(It.IsAny<System.Collections.Generic.IEnumerable<string>>(), It.IsAny<string>()))
                .Returns("Learner");
            _jwtMock.Setup(j => j.GenerateJwtToken(claims, "Learner", out It.Ref<DateTime>.IsAny))
                .Callback((SSOClaimsDto c, string role, out DateTime exp) => exp = DateTime.UtcNow.AddHours(8))
                .Returns("our.jwt.token");
            _jwtMock.Setup(j => j.GenerateRefreshToken()).Returns("refresh-token");

            var controller = CreateController();
            var result = await controller.Callback(request);

            var ok = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<AuthResponseDto>(ok.Value);
            Assert.Equal("our.jwt.token", dto.AccessToken);
            Assert.Equal("refresh-token", dto.RefreshToken);
            Assert.Equal("Learner", dto.Role);
        }

        [Fact]
        public async Task Callback_Handles_UnauthorizedAccessException_Gracefully()
        {
            var request = new SSOCallbackRequest { Code = "c", RedirectUri = "https://app/redirect" };

            _ssoMock.Setup(s => s.ExchangeAuthorizationCodeAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new UnauthorizedAccessException("tampered"));

            var controller = CreateController();
            var result = await controller.Callback(request);

            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}