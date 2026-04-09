using System.Collections.Generic;
using API.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace API.Tests
{
    public class RoleMappingServiceTests
    {
        private readonly RoleMappingService _service;
        private readonly Mock<ILogger<RoleMappingService>> _loggerMock = new();

        public RoleMappingServiceTests()
        {
            _service = new RoleMappingService(_loggerMock.Object);
        }

        [Fact]
        public void Maps_Admin_Group_To_Admin()
        {
            var roles = new[] { "AAD_Group_AI_Admins" };
            var result = _service.MapSSORoleToAppRole(roles, "a@b.com");
            Assert.Equal("Admin", result);
        }

        [Fact]
        public void Maps_Leadership_Priority_Over_Admin()
        {
            var roles = new[] { "AAD_Group_AI_Admins", "AAD_Group_Leadership" };
            var result = _service.MapSSORoleToAppRole(roles, "a@b.com");
            Assert.Equal("Leadership", result);
        }

        [Fact]
        public void Maps_Unrecognized_To_Learner_And_LogsWarning()
        {
            var roles = new[] { "SOMETHING_UNKNOWN" };
            var result = _service.MapSSORoleToAppRole(roles, "a@b.com");
            Assert.Equal("Learner", result);
            // logger called with warning
            _loggerMock.Verify(l => l.Log(
                It.Is<Microsoft.Extensions.Logging.LogLevel>(ll => ll == Microsoft.Extensions.Logging.LogLevel.Warning),
                It.IsAny<EventId>(),
                It.IsAny<It.IsValueType>(),
                It.IsAny<System.Exception>(),
                It.IsAny<System.Func<object, System.Exception?, string>>()), Times.AtLeastOnce);
        }

        [Fact]
        public void NullRoles_Defaults_To_Learner()
        {
            var result = _service.MapSSORoleToAppRole(null, "a@b.com");
            Assert.Equal("Learner", result);
        }
    }
}