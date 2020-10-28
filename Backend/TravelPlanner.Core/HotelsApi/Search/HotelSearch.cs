using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Search
{
    public class HotelSearch
    {
        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("moresuggestions")]
        public int MoreSuggestions { get; set; }

        [JsonProperty("autoSuggestInstance")]
        public string AutoSuggestInstance { get; set; }

        [JsonProperty("trackingID")]
        public string TrackingId { get; set; }

        [JsonProperty("misspellingfallback")]
        public bool MissspellingFallback { get; set; }

        [JsonProperty("suggestions")]
        public Item[] Suggestions { get; set; }
    }
}
