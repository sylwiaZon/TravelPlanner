using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class StructuredContentTopic
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("coordinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("object_id")]
        public string ObjectId { get; set; }

        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
