using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class AirportFlightStatus
    {
        [JsonProperty("AirportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("ScheduledTimeLocal")]
        public ScheduledTime ScheduledTimeLocal { get; set; }

        [JsonProperty("ScheduledTimeUTC")]
        public ScheduledTime ScheduledTimeUTC { get; set; }

        [JsonProperty("TimeStatus")]
        public TimeStatus TimeStatus { get; set; }

        [JsonProperty("Terminal")]
        public Terminal Terminal { get; set; }
    }
}
