using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Common
    {
        [JsonProperty("pointOfSale")]
        public PointOfSale PointOfSale { get; set; }

        [JsonProperty("tracking")]
        public Tracking Tracking { get; set; }
    }
}
