using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Photos
{
    public class Size
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }
}
