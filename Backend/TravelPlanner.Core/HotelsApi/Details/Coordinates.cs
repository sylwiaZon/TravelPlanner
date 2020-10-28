using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Coordinates
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
