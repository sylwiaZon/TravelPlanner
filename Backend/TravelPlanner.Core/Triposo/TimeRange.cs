using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class TimeRange
    {
        [JsonProperty("end")]
        public DayTime End { get; set; }

        [JsonProperty("start")]
        public DayTime Start { get; set; }
    }
}
