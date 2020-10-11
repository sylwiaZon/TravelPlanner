using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class MusementLocation
    {
        [JsonProperty("district_tag")]
        public string DistrictTag { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("musement_id")]
        public string MusementId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
