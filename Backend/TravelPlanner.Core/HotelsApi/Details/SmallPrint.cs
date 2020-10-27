using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class SmallPrint
    {
        [JsonProperty("alternativeNames")]
        public string[] AlternativeNames { get; set; }

        [JsonProperty("mandatoryFees")]
        public string[] MandatoryFees { get; set; }

        [JsonProperty("optionalExtras")]
        public string[] OprionalExtras { get; set; }

        [JsonProperty("policies")]
        public string[] Policies { get; set; }

        [JsonProperty("mandatoryTaxesOrFees")]
        public bool MandatoryTaxesOrFees { get; set; }

        [JsonProperty("display")]
        public bool Display { get; set; }
    }
}
