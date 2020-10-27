using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class GuestReviews
    {
        [JsonProperty("brands")]
        public Brands Brands { get; set; }

        [JsonProperty("trustYouReviews")]
        public TrustYouReview[] TrustYouReviews { get; set; }
    }
}
