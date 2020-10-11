using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Location
    {
        [JsonProperty("attribution")]
        public Attribution[] Attributions { get; set; }

        [JsonProperty("climate")]
        public Climate Climate { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("coordinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("intro_language_info")]
        public LanguageInfo IntroLanguageInfo { get; set; }

        [JsonProperty("musement_location")]
        public MusementLocation[] MusementLocations { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("paret_id")]
        public string ParentId { get; set; }

        [JsonProperty("part_of")]
        public string[] PartOf { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("public_transport_maps")]
        public Image[] PublicTransportMaps { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("snippet_language_info")]
        public LanguageInfo SnippetLanguageInfo { get; set; }

        [JsonProperty("structured_content")]
        public StructuredContent StructuredContent { get; set; }

        [JsonProperty("structured_content_language_info")]
        public LanguageInfo StructuredContentLanguageInfo { get; set; }

        [JsonProperty("tag_labels")]
        public string[] TagLabels { get; set; }

        [JsonProperty("tags")]
        public TagWithScore[] Tags { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
