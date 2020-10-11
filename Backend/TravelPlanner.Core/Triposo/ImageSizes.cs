using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ImageSizes
    {
        [JsonProperty("medium")]
        public ImageSize Medium { get; set; }

        [JsonProperty("original")]
        public ImageSize Original { get; set; }

        [JsonProperty("thumbnail")]
        public ImageSize Thumbnail { get; set; }
    }
}
