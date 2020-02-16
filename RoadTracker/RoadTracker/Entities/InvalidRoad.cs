using System;

namespace RoadTracker.Entities
{
    public class InvalidRoad : Road
    {
        public DateTime TimeStampUTC { get; set; }
        public string ExceptionType { get; set; }
        public int HttpStatusCode { get; set; }
        public string HttpStatus { get; set; }
        public string RelativeUri { get; set; }
        public string Message { get; set; }
    }
}
