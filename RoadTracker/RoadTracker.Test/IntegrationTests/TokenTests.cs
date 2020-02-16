using NUnit.Framework;
using RoadTracker.Services;

namespace Tests
{
    public class TokenTests
    {
        [Test]
        public void GetTokenShouldReturnAValidID()
        {
            var config = Configuration.SetupConfiguration();

            Assert.IsNotNull(config["app_id"]);
        }

        [Test]
        public void GetTokenShouldReturnAValidKey()
        {
            var config = Configuration.SetupConfiguration();

            Assert.IsNotNull(config["app_key"]);
        }

        [Test]
        public void GetTokenShouldReturnAValidUrl()
        {
            var config = Configuration.SetupConfiguration();

            Assert.IsNotNull(config["service_root_url"]);
        }
        
    }
}
