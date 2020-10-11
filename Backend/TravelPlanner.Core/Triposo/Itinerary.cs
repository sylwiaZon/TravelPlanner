using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Itinerary
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("itinerary_items")]
        public ItineraryItem[] ItineraryItems { get; set; }
    }
}
