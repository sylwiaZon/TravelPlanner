using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Photos
{
    public class Image
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("imageId")]
        public long ImageId { get; set; }

        [JsonProperty("mediaGUID")]
        public string MediaGuid { get; set; }

        [JsonProperty("sizes")]
        public Size[] Sizes { get; set; }
    }
}
