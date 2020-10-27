using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class SpecialFeatures
    {
        [JsonProperty("sections")]
        public Section[] Sections { get; set; }
    }
}
