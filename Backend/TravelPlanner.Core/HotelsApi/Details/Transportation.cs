using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Transportation
    {
        [JsonProperty("transportLocations")]
        public TransportLocation[] TransportLocations { get; set; }
    }
}
