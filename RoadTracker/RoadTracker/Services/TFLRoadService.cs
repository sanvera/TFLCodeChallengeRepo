using RoadTracker.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadTracker.Services
{
    public class TFLRoadService : ITFLRoadService
    {
        private readonly Token _token;

        public TFLRoadService(Token APIKey)
        {
            _token = APIKey;
        }

        public string FindRoadStatus(string roadId)
        {
            var callTask = Task.Run(() => TFLServiceCall(roadId));
            callTask.Wait();
            return callTask.Result;
        }

        private async Task<string> TFLServiceCall(string roadId)
        {
            var client = new HttpClient();

            string serviceUrl = $"{_token.ServiceRootUrl}/{roadId}?app_id={_token.ApplicationId}&app_key={_token.ApplicationKey}";
            var response = await client.GetAsync(serviceUrl);
            var roadStatus = await response.Content.ReadAsStringAsync();
            return roadStatus;
        }
    }
}
