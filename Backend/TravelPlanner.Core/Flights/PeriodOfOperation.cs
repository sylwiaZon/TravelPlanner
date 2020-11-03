using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class PeriodOfOperation
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("daysOfOperation")]
        public string DaysOfOperation { get; set; }
    }
}
