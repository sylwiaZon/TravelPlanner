using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Body
    {
        [JsonProperty("pdpHeader")]
        public PdpHeader PdhHeader { get; set; }

        [JsonProperty("overview")]
        public Overview Overview { get; set; }

        [JsonProperty("hotelWelcomeRewards")]
        public HotelWelcomeRewards HotelWelcomeRewards { get; set; }

        [JsonProperty("propertyDescription")]
        public PropertyDescription PropertyDescription { get; set; }

        [JsonProperty("guestReviews")]
        public GuestReviews GuestReviews { get; set; }

        [JsonProperty("atAGlance")]
        public AtAGlance AtAGlance { get; set; }

        [JsonProperty("amenities")]
        public Amenity[] Amenities { get; set; }

        [JsonProperty("hygieneAndCleanliness")]
        public HygieneAndCleanliness HygieneAndCleanliness { get; set; }

        [JsonProperty("smallPrint")]
        public SmallPrint SmallPrint { get; set; }

        [JsonProperty("specialFeatures")]
        public SpecialFeatures SpecialFeatures { get; set; }

        [JsonProperty("miscellaneous")]
        public Miscellaneous Miscellaneous { get; set; }

        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("trustYouReviewsCredit")]
        public bool TrustYouReviewsCredit { get; set; }

        [JsonProperty("hotelBadge")]
        public HotelBadge HotelBadge { get; set; }
    }
}
