using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Tag
    {
        [JsonProperty("article_count")]
        public int ArticleCount { get; set; }

        [JsonProperty("child_labels")]
        public string[] ChildLabels { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("internal")]
        public bool Internal { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_language_info")]
        public LanguageInfo NameLanguageInfo { get; set; }

        [JsonProperty("parent_labels")]
        public string[] ParentLabels { get; set; }

        [JsonProperty("poi_count")]
        public int PoiCount { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("snippet_language_info")]
        public LanguageInfo SnippetLanguageInfo { get; set; }

        [JsonProperty("structured_content")]
        public StructuredContent StructuredContent { get; set; }

        [JsonProperty("structured_content_language_info")]
        public LanguageInfo StructuredContentLanguageInfo { get; set; }

        [JsonProperty("tour_content")]
        public int TourContent { get; set; }
    }
}
