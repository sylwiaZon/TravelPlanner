using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class LocalScore
    {
        [JsonProperty("coordinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("scores")]
        public TagLabelWithScore[] Scores { get; set; }
    }
}
