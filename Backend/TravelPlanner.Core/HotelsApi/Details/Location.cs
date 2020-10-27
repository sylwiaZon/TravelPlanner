using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("distanceInTime")]
        public string DistanceInTime { get; set; }
    }
}
