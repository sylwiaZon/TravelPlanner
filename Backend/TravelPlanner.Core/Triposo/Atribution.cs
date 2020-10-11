using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Atribution
    {
        [JsonProperty("spurce_id")]
        public string SourceId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
