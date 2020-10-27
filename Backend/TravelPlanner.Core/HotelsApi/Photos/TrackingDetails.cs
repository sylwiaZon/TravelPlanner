using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Photos
{
    public class TrackingDetails
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("algorithmName")]
        public string AlgorithmName { get; set; }
    }
}
