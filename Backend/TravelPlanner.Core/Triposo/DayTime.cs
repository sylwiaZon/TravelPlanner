using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class DayTime
    {
        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }
    }
}
