using Moq;
using NUnit.Framework;
using RoadTracker.Entities;
using RoadTracker.Services;
using RoadTracker.Test.Entities;
using System.Linq;

namespace Tests.UnitTests
{
    public class RoadStatusFinderTests
    {
        private readonly Mock<ITFLRoadService> _tflService;
        private readonly IRoadStatusFinder _roadTracker;

        public RoadStatusFinderTests()
        {
            _tflService = new Mock<ITFLRoadService>();
            _roadTracker = new RoadStatusFinder(_tflService.Object);
        }

        [Test]
        [TestCase("A2")]
        [TestCase("A12")]
        public void GetCorrectRoadInformationShouldReturnCorrectValue(string roadId)
        {
            _tflService.Setup(x => x.FindRoadStatus(It.IsAny<string>())).Returns(FakeResponse.ValidResponse.First(x => x.Contains(roadId)));
            var result = _roadTracker.GetRoadInformation(roadId);

            Assert.IsNotNull(result);
            Assert.AreEqual(roadId, result.Id.ToUpper());
            Assert.AreEqual(roadId, result.DisplayName);
            Assert.NotNull(result.StatusSeverity);
            Assert.NotNull(result.StatusSeverityDescription);
            Assert.NotNull(result.Url);
        }

        [Test]
        [TestCase("A90")]
        [TestCase("A203")]
        public void GetIncorrectRoadInformationShouldReturnNull(string roadId)
        {
            _tflService.Setup(x => x.FindRoadStatus(It.IsAny<string>())).Returns(FakeResponse.InvalidResponse[0]);
            var result = _roadTracker.GetRoadInformation(roadId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCaseSource(typeof(FakeResponse), nameof(FakeResponse.InvalidResponse))]
        public void ParseTFLInvalidResponseShouldNotThrowException(string road)
        {
            string response = road.ToString();
            Assert.DoesNotThrow(() => _roadTracker.ParseTFLResponse(response));
        }

        [Test]
        [TestCaseSource(typeof(FakeResponse), nameof(FakeResponse.ValidResponse))]
        public void ParseTFLValidResponseShouldNotThrowException(string road)
        {
            string response = road.ToString();
            Assert.DoesNotThrow(() => _roadTracker.ParseTFLResponse(response));
        }

        [Test]
        [TestCaseSource(typeof(FakeResponse), nameof(FakeResponse.InvalidResponse))]
        public void ParseTFLResponseShouldreturnInValidRoad(string road)
        {
            Assert.IsInstanceOf<InvalidRoad>(_roadTracker.ParseTFLResponse(road));
        }


        [Test]
        [TestCaseSource(typeof(FakeResponse), nameof(FakeResponse.ValidResponse))]
        public void ParseTFLResponseShouldreturnValidRoadArray(string road)
        {
            Assert.IsInstanceOf<ValidRoad[]>(_roadTracker.ParseTFLResponse(road));
        }

        [Test]
        [TestCase("A2")]
        [TestCase("A40")]
        public void GetValidRoadShouldReturnValidRoadWhenTheRoadArrayIsValid(string roadId)
        {
            var validRoad = new ValidRoad[] { new ValidRoad() { Id = roadId } };
            var result = _roadTracker.GetValidRoad(validRoad);
            Assert.NotNull(result);
            Assert.AreEqual(roadId, result.Id);
        }

        [Test]
        public void GetValidRoadShouldReturnNullWhenTheRoadArrayIsInValid()
        {
            var invalidRoad = new InvalidRoad();
            var result = _roadTracker.GetValidRoad(invalidRoad);
            Assert.IsNull(result);
        }

        [Test]
        public void GetValidRoadShouldReturnNullWhenTheRoadArrayIsNull()
        {
            object road = null;
            var result = _roadTracker.GetValidRoad(road);
            Assert.IsNull(result);
        }

    }
}