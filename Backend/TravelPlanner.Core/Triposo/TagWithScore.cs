using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class TagWithScore
    {
        [JsonProperty("object_score")]
        public float ObjectScore { get; set; }

        [JsonProperty("tag")]
        public Tag Tag { get; set; }
    }
}
