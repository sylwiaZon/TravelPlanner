using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class ScheduleResource
    {
        [JsonProperty("Schedule")]
        public Schedule[] Schedule { get; set; }
    }
}
