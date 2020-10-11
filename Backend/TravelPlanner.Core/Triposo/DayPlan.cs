using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class DayPlan
    {
        [JsonProperty("days")]
        public Itinerary[] Days { get; set; }

        [JsonProperty("hotels")]
        public Poi Hotel { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("seed")]
        public int Seed { get; set; }
    }
}
