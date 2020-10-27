using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class TransportAndOther
    {
        [JsonProperty("transport")]
        public Transport Transport { get; set; }

        [JsonProperty("otherInformation")]
        public string[] OtherInformation { get; set; }

        [JsonProperty("otherInclusions")]
        public string[] OtherInclusions { get; set; }
    }
}
