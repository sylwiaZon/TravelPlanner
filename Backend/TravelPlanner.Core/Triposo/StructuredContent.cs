using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class StructuredContent
    {
        [JsonProperty("attribution")]
        public Attribution[] Attributions { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("sections")]
        public StructuredContentSection[] Sections { get; set; }
    }
}
