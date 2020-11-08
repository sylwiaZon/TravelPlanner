using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class NearestAirportResource
    {
        [JsonProperty("Airports")]
        public Airports Airports { get; set; }
    }
}
