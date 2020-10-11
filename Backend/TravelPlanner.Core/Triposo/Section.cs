using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Section
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
