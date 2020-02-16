using RoadTracker.Entities;

namespace RoadTracker.Services
{
    public interface IRoadStatusFinder
    {
        ValidRoad GetRoadInformation(string roadId);
        object ParseTFLResponse(string roadInfo);
        ValidRoad GetValidRoad(object road);
    }
}