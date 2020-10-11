using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ImageSize
    {
        [JsonProperty("bytes")]
        public int Bytes { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
