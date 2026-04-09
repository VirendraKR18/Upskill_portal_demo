using System;
using System.Threading.Tasks;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace API.Tests
{
    public class SSOServiceTests
    {
        // These are integration-light tests. We can't call real Azure AD.
        // We'll test that constructor validates config and that ExchangeAuthorizationCodeAsync
        // throws when metadata/token endpoint unreachable.

        [Fact]
        public void Constructor_Throws_On_Missing_Config()
        {
            var settings = new System.Collections.Generic.Dictionary<string, string>();
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
            var logger = new Mock<ILogger<SSOService>>().Object;
            Assert.Throws<ArgumentException>(() => new SSOService(configuration, logger));
        }

        [Fact]
        public async Task ExchangeAuthorizationCodeAsync_Throws_On_Unreachable_Metadata()
        {
            var settings = new System.Collections.Generic.Dictionary<string, string>
            {
                {"Authentication:AzureAd:Instance", "https://login.microsoftonline.com"},
                {"Authentication:AzureAd:TenantId", "invalid-tenant"},
                {"Authentication:AzureAd:ClientId", "clientid"},
                {"Authentication:AzureAd:ClientSecret", ""}
            };
            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
            var logger = new Mock<ILogger<SSOService>>().Object;
            var svc = new SSOService(configuration, logger);

            // Expect exception because tenant metadata will not resolve for invalid tenant
            await Assert.ThrowsAsync<InvalidOperationException>(() => svc.ExchangeAuthorizationCodeAsync("code", "https://app/redirect"));
        }
    }
}