using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class OpeningHours
    {
        [JsonProperty("days")]
        public TimeRangesByDay Days { get; set; }

        [JsonProperty("open_24_7")]
        public bool OpenAllDay { get; set; }
    }
}
