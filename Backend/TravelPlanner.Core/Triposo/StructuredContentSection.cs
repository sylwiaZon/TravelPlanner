using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class StructuredContentSection
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("body_images")]
        public int[] BodyImages { get; set; }

        [JsonProperty("coorinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("object_id")]
        public string ObjectId { get; set; }

        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        [JsonProperty("sections")]
        public StructuredContentSection[] Sections { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("topics")]
        public StructuredContentTopic[] Topics { get; set; }
    }
}
