using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Content
    {
        [JsonProperty("atribution")]
        public Attribution[] Attributions { get; set; }

        [JsonProperty("section")]
        public Section[] Sections { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
