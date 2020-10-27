using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Miscellaneous
    {
        [JsonProperty("pimmsAttributes")]
        public string PimmsAttributes { get; set; }

        [JsonProperty("showLegalInfoForStrikethroughPrices")]
        public bool ShowLegalInfoForStrikethroughPrices { get; set; }

        [JsonProperty("legalInfoForStrikethroughPrices")]
        public string LegalInfoForStrikethroughPrices { get; set; }
    }
}
