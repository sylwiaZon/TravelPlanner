using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Point
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
