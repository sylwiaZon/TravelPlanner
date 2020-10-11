using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class TagLabelWithScore
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("tag_label")]
        public string TagLabel { get; set; }
    }
}
