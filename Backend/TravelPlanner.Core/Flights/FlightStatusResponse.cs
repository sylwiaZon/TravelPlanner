using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class FlightStatusResponse
    {
        [JsonProperty("FlightStatusResource")]
        public FlightStatusResponseObj FlightStatusResource { get; set; }
    }
}
