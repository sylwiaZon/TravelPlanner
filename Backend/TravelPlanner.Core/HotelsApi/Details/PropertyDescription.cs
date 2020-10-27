using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class PropertyDescription
    {
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("priceMatchEnables")]
        public bool PriceMatchEnabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("starRatingTitle")]
        public string StarRatingTitle { get; set; }

        [JsonProperty("starRating")]
        public string StarRating { get; set; }

        [JsonProperty("featuredPrice")]
        public FeaturedPrice FeaturedPrice { get; set; }
    }
}
