using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class TrustYouReview
    {
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("sentimental")]
        public string Sentimental { get; set; }
    }
}
