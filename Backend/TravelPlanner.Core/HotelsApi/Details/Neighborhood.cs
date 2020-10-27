using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Neighborhood
    {
        [JsonProperty("neighborhoodName")]
        public string NeighborhoodName { get; set; }
    }
}
