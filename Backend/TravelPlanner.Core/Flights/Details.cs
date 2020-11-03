using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Details
    {
        [JsonProperty("Stops")]
        public Stops Stops { get; set; }

        [JsonProperty("DaysOfOperation")]
        public string DaysOfOperation { get; set; }

        [JsonProperty("DatePeriod")]
        public DatePeriod DatePeriod { get; set; }
    }
}
