using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class AtAGlance
    {
        [JsonProperty("keyFacts")]
        public KeyFacts KeyFacts { get; set; }

        [JsonProperty("travellingOrInternet")]
        public TravellingOrInternet TravellingOrInternet { get; set; }

        [JsonProperty("transportAndOther")]
        public TransportAndOther TransportAndOther { get; set; }
    }
}
