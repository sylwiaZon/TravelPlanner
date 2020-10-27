using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class CurrentPrice
    {
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        [JsonProperty("plain")]
        public string Plain { get; set; }
    }
}
