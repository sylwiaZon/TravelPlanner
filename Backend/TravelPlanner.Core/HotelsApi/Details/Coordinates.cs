using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Coordinates
    {
        [JsonProperty("latitude")]
        public int Latitude { get; set; }

        [JsonProperty("longitude")]
        public int Longitude { get; set; }
    }
}
