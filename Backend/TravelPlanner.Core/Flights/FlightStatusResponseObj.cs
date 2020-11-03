using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class FlightStatusResponseObj
    {
        [JsonProperty("Flights")]
        public FlightsObj Flights { get; set; }
    }
}
