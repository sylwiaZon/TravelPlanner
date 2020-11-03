using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class DatePeriod
    {
        [JsonProperty("Effective")]
        public string Effective { get; set; }

        [JsonProperty("Expiration")]
        public string Expiration { get; set; }
    }
}
