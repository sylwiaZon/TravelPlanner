using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class TotalJourney
    {
        [JsonProperty("Duration")]
        public string Duration { get; set; }
    }
}
