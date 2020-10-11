using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Attribution
    {
        [JsonProperty("source_id")]
        public string SourceID { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
