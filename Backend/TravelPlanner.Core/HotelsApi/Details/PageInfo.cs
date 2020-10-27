using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class PageInfo
    {
        [JsonProperty("pageType")]
        public string PageType { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }

        [JsonProperty("errorKeys")]
        public string[] ErrorKeys { get; set; }
    }
}
