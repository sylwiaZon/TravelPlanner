using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HygieneAndCleanliness
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("hygieneQualifications")]
        public HygieneQualifications HygieneQualifications { get; set; }

        [JsonProperty("healthAndSafetyMeasures")]
        public HealthAndSafetyMeasures HealthAndSafetyMeasures { get; set; }
    }
}
