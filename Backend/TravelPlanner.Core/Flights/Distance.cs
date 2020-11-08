using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Distance
    {
        [JsonProperty("Value")]
        public float Value { get; set; }

        [JsonProperty("UOM")]
        public string Unit { get; set; }
    }
}
