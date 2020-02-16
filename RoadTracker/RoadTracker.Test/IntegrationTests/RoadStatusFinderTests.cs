using NUnit.Framework;
using RoadTracker;
using RoadTracker.Services;

namespace Tests.IntegrationTests
{
    public class RoadStatusFinderIntegrationTests
    {
        private readonly IRoadStatusFinder _roadTracker;
        private readonly ITFLRoadService _tflService;

        public RoadStatusFinderIntegrationTests()
        {
            var tokenRepository = new TokenRepository(Configuration.SetupConfiguration());
            var APIKey = tokenRepository.GetToken();
            _tflService = new TFLRoadService(APIKey);
            _roadTracker = new RoadStatusFinder(_tflService);
        }

        [Test]
        [TestCase("A1")]
        [TestCase("A2")]
        public void WhenCorrectRoadIdSentCorrectRoadInformationShouldReturn(string roadId)
        {
            var result = _roadTracker.GetRoadInformation(roadId);

            Assert.NotNull(result);
            Assert.AreEqual(roadId, result.Id.ToUpper());
            Assert.AreEqual(roadId, result.DisplayName);
            Assert.NotNull(result.DisplayName);
            Assert.NotNull(result.StatusSeverity);
            Assert.NotNull(result.StatusSeverityDescription);
            Assert.NotNull(result.Url);
        }

        [Test]
        [TestCase("A90")]
        [TestCase("A203")]
        public void GetIncorrectRoadInformationShouldReturnNull(string roadId)
        {
            var result = _roadTracker.GetRoadInformation(roadId);

            Assert.Null(result);
        }
    }
}