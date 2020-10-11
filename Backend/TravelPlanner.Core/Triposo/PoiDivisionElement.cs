using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class PoiDivisionElement
    {
        [JsonProperty("poi_ids")]
        public string[] PoiIds { get; set; }

        [JsonProperty("tag_label")]
        public string TagLabel { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }
    }
}
