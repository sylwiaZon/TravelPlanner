using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Price
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
