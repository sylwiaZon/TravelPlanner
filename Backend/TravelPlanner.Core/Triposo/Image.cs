using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Image
    {
        [JsonProperty("attribution")]
        public ImageAttribution Attribution { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("sizes")]
        public ImageSizes Sizes { get; set; }

        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
    }
}
