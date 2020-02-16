using Microsoft.Extensions.Configuration;
using RoadTracker.Entities;

namespace RoadTracker
{
    public class TokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token GetToken()
        {
            return new Token()
            {
                ApplicationId = _configuration["app_id"],
                ApplicationKey = _configuration["app_key"],
                ServiceRootUrl = _configuration["service_root_url"]
            };
        }
    }
}
