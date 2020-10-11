using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Article
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("intro_language_info")]
        public LanguageInfo IntroLanguageInfo { get; set; }

        [JsonProperty("location_ids")]
        public string[] LocationIds { get; set; }
        
        [JsonProperty("name_language_info")]
        public LanguageInfo NameLanguageInfo { get; set; }
        
        [JsonProperty("pois")]
        public Poi[] Pois { get; set; }

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
