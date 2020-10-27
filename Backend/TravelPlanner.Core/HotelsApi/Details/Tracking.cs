using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Tracking
    {
        [JsonProperty("pageViewBeaconUrl")]
        public string PageViewBeaconUrl { get; set; }
    }
}
