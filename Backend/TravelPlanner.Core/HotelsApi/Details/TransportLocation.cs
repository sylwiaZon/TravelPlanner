using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class TransportLocation
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    }
}
