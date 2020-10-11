using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class TimeRangesByDay
    {
        [JsonProperty("fri")]
        public TimeRange[] Fri { get; set; }

        [JsonProperty("mon")]
        public TimeRange[] Mon { get; set; }

        [JsonProperty("aat")]
        public TimeRange[] Sat { get; set; }

        [JsonProperty("sun")]
        public TimeRange[] Sun { get; set; }

        [JsonProperty("thu")]
        public TimeRange[] Thu { get; set; }

        [JsonProperty("tue")]
        public TimeRange[] Tue { get; set; }

        [JsonProperty("wed")]
        public TimeRange[] Wed { get; set; }

    }
}
