using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Stops
    {
        [JsonProperty("StopQuantity")]
        public string StopQuantity { get; set; }
    }
}
