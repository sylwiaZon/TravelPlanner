using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HygieneQualifications
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("qualifications")]
        public string[] Qualifications { get; set; }
    }
}
