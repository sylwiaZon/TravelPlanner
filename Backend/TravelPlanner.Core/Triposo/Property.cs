using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Property
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("poi_id")]
        public string PoiId { get; set; }

        [JsonProperty("tour_id")]
        public string TourId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
