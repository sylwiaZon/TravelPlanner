using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HealthAndSafetyMeasures
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("measures")]
        public string[] Measures { get; set; }
    }
}
