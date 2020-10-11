using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class CityWalk
    {
        [JsonProperty("seed")]
        public int Seed { get; set; }

        [JsonProperty("total_duration")]
        public int TotalDuration { get; set; }

        [JsonProperty("walk_distance")]
        public int WalkDistance { get; set; }

        [JsonProperty("walk_duration")]
        public int WalkDuration { get; set; }

        [JsonProperty("way_points")]
        public WayPoint[] WayPoints { get; set; }
    }
}
