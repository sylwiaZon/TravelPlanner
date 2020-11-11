using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class WayPoint
    {
        [JsonProperty("coordinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("poi")]
        public Poi Poi { get; set; }

        [JsonProperty("visit_time")]
        public int VisitTime { get; set; }

        [JsonProperty("walk_to_next_distance")]
        public int WalkToNextDistance { get; set; }

        [JsonProperty("walk_to_next_duration")]
        public int WalkToNextDuration { get; set; }
    }
}
