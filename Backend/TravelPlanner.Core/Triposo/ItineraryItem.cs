using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ItineraryItem
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("poi")]
        public Poi Poi { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
