using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Poi
    {
        [JsonProperty("attribution")]
        public Attribution[] Attributions { get; set; }

        [JsonProperty("best_for")]
        public Tag[] BestFor { get; set; }

        [JsonProperty("booking_info")]
        public BookingInfo BookingInfo { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("coordinates")]
        public Point Coordinates { get; set; }

        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("intro_language_info")]
        public LanguageInfo IntroLanguageInfo { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("location_ids")]
        public string[] LocationIds { get; set; }

        [JsonProperty("musement_venue_id")]
        public string MusementVenuseId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("price_tier")]
        public int PriceTier { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("snippet_language_info")]
        public LanguageInfo SnippetLanguageInfo { get; set; }

        [JsonProperty("structured_content")]
        public StructuredContent StructuredContent { get; set; }

        [JsonProperty("structured_content_language_info")]
        public LanguageInfo StructuedContentLanguageInfo { get; set; }

        [JsonProperty("tag_labels")]
        public string[] TagLabels { get; set; }

        [JsonProperty("tags")]
        public TagWithScore Tags { get; set; }

        [JsonProperty("tour_ids")]
        public string[] TourIds { get; set; }
    }
}
