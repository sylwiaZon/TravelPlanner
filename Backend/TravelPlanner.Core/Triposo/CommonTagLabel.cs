using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class CommonTagLabel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("internal")]
        public bool Internal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parents")]
        public string[] Parents { get; set; }
    }
}
