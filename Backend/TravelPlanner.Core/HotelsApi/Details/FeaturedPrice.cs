using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class FeaturedPrice
    {
        [JsonProperty("beforePriceText")]
        public string BeforePriceText { get; set; }

        [JsonProperty("afterPriceText")]
        public string AfterPriceText { get; set; }

        [JsonProperty("pricingAvailability")]
        public string PricingAvailability { get; set; }

        [JsonProperty("pricingTooltip")]
        public string PricingTooltip { get; set; }

        [JsonProperty("currentPrice")]
        public CurrentPrice CurrentPrice { get; set; }

        [JsonProperty("oldPrice")]
        public string OldPrice { get; set; }

        [JsonProperty("txInclusiveFormatting")]
        public bool TaxInclusiveFormatting { get; set; }

        [JsonProperty("bookNowButton")]
        public bool BookNowButton { get; set; }
    }
}
