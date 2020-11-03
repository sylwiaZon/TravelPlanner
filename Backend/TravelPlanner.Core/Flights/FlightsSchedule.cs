using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class FlightsSchedule
    {
        [JsonProperty("ScheduleResource")]
        public ScheduleResource ScheduleResource { get; set; }
    }
}
