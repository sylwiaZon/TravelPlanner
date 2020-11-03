using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class ScheduleResponse
    {
        [JsonProperty("ScheduleResource")]
        public ScheduleResource ScheduleResource { get; set; }
    }
}
