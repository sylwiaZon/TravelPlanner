using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Transport
    {
        [JsonProperty("transfers")]
        public string[] Transfers { get; set; }

        [JsonProperty("parking")]
        public string[] Parking { get; set; }

        [JsonProperty("offsiteTransfer")]
        public string[] OffsiteTransfer { get; set; }
    }
}
