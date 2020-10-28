using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Brands
    {
        [JsonProperty("scale")]
        public float Scale { get; set; }

        [JsonProperty("formattedScale")]
        public string FormattedScale { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("formattedRating")]
        public string FormattedRating { get; set; }

        [JsonProperty("lowRating")]
        public bool LowRating { get; set; }

        [JsonProperty("badgeText")]
        public string BadgeText { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
