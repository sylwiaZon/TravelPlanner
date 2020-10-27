using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class PointOfSale
    {
        [JsonProperty("numberSeparators")]
        public string NumberSeparators { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }
    }
}
