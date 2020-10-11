using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class LocalHighlights
    {
        [JsonProperty("poi_division")]
        public PoiDivisionElement[] PoiDivisions { get; set; }

        [JsonProperty("pois")]
        public Poi[] Pois { get; set; }
    }
}
