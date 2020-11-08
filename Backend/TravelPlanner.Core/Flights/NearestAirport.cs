using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class NearestAirport
    {
        [JsonProperty("NearestAirportResource")]
        public NearestAirportResource NearestAirportResource { get; set; }
    }
}
