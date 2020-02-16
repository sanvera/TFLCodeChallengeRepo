using Microsoft.Extensions.Configuration;

namespace RoadTracker.Services
{
    public static class Configuration
    {
        public static IConfiguration SetupConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}
