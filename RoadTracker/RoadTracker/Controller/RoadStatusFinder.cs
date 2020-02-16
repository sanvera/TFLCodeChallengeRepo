using Newtonsoft.Json;
using RoadTracker.Entities;
using System;
using System.Linq;

namespace RoadTracker.Services
{
    public class RoadStatusFinder : IRoadStatusFinder
    {
        private readonly ITFLRoadService _tflService;

        public RoadStatusFinder(ITFLRoadService tflService)
        {
            _tflService = tflService;
        }

        public ValidRoad GetRoadInformation(string roadId)
        {
            try
            {
                var response = _tflService.FindRoadStatus(roadId);
                var roadDetails = ParseTFLResponse(response);
                return GetValidRoad(roadDetails);
            }
            catch
            {
                return null;
            }
        }

        public object ParseTFLResponse(string roadInfo)
        {
            try
            {
                return JsonConvert.DeserializeObject<ValidRoad[]>(roadInfo);
            }
            catch
            {
                try
                {
                    return JsonConvert.DeserializeObject<InvalidRoad>(roadInfo);
                }
                catch
                {
                    return null;
                }
            }
        }

        public ValidRoad GetValidRoad(object road)
        {
            if (road == null)
                return null;

            Type t = road.GetType();

            if (t == typeof(ValidRoad[]))
            {
                var roadDetails = (ValidRoad[])road;
                return roadDetails.ToList().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
