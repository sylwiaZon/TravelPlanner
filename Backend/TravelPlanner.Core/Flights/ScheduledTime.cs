using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class ScheduledTime
    {
        [JsonProperty("DateTime")]
        public string DateTime { get; set; }
    }
}
