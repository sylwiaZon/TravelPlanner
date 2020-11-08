using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Airports
    {
        [JsonProperty("Airport")]
        public Airport[] Airport { get; set; }
    }
}
