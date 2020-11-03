using System;

namespace TravelPlanner.Core.Exceptions
{
    public class TravelPlannerException : Exception
    {
        public int StatusCode { get; }
        public override string Message { get; }

        public TravelPlannerException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
