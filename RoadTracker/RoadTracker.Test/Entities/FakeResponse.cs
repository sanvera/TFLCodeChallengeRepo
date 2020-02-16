using System.Collections.Generic;

namespace RoadTracker.Test.Entities
{
    public class FakeResponse
    {
        public static List<string> InvalidResponse = new List<string> {
                    "{\"$type\":\"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\",\"timestampUtc\":\"2019-02-07T18:08:17.0189502Z\",\"exceptionType\":\"EntityNotFoundException\",\"httpStatusCode\":404,\"httpStatus\":\"NotFound\",\"relativeUri\":\"/Road/A209\",\"message\":\"The following road id is not recognised: A209\"}",
                    "{\"$type\":\"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\",\"timestampUtc\":\"2019-02-07T18:09:03.1390484Z\",\"exceptionType\":\"EntityNotFoundException\",\"httpStatusCode\":404,\"httpStatus\":\"NotFound\",\"relativeUri\":\"/Road/A305\",\"message\":\"The following road id is not recognised: A305\"}",
                    "{\"$type\":\"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\",\"timestampUtc\":\"2019-02-07T18:09:42.7786481Z\",\"exceptionType\":\"EntityNotFoundException\",\"httpStatusCode\":404,\"httpStatus\":\"NotFound\",\"relativeUri\":\"/Road/A65\",\"message\":\"The following road id is not recognised: A65\"}"
                };

        public static List<string> ValidResponse = new List<string> {
                    "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a2\",\"displayName\":\"A2\",\"statusSeverity\":\"Good\",\"statusSeverityDescription\":\"No Exceptional Delays\",\"bounds\":\"[[-0.0857,51.44091],[0.17118,51.49438]]\",\"envelope\":\"[[-0.0857,51.44091],[-0.0857,51.49438],[0.17118,51.49438],[0.17118,51.44091],[-0.0857,51.44091]]\",\"url\":\"/Road/a2\"}]",
                    "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a12\",\"displayName\":\"A12\",\"statusSeverity\":\"Serious\",\"statusSeverityDescription\":\"Serious Delays\",\"bounds\":\"[[-0.07183,51.51187],[0.28532,51.60844]]\",\"envelope\":\"[[-0.07183,51.51187],[-0.07183,51.60844],[0.28532,51.60844],[0.28532,51.51187],[-0.07183,51.51187]]\",\"url\":\"/Road/a12\"}]",
                    "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a205\",\"displayName\":\"South Circular (A205)\",\"statusSeverity\":\"Closure\",\"statusSeverityDescription\":\"Closure\",\"bounds\":\"[[-0.27716,51.43917],[0.06343,51.49446]]\",\"envelope\":\"[[-0.27716,51.43917],[-0.27716,51.49446],[0.06343,51.49446],[0.06343,51.43917],[-0.27716,51.43917]]\",\"url\":\"/Road/a205\"}]"
                };
    }
}
