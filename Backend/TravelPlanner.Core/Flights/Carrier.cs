using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Carrier
    {
        [JsonProperty("AirlineID")]
        public string AirlineId { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }
    }
}
