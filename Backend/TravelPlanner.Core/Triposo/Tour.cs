using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Tour
    {
        [JsonProperty("atribution")]
        public Attribution[] Attributions { get; set; }

        [JsonProperty("booking_info")]
        public BookingInfo BookingInfo { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("duration")]
        public float Duartion { get; set; }

        [JsonProperty("duration_unit")]
        public string DurationUnit { get; set; }
    
        [JsonProperty("highlights")]
        public string[] Highlights { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("location_ids")]
        public string[] LocationIds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poi_ids")]
        public string[] PoiIds { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("price_is_per_person")]
        public bool PriceIsPerPerson { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("structured_content")]
        public StructuredContent StructuredContent { get; set; }

        [JsonProperty("tag_labels")]
        public string[] TagLabels { get; set; }

        [JsonProperty("tags")]
        public TagWithScore[] Tags { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("vendor_tour_url")]
        public string VendorTourUrl { get; set; }
    }
}
