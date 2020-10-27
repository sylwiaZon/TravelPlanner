using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class OverViewSection
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string[] Content { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }
    }
}
