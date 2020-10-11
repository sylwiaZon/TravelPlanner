using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ClimateStatistics
    {
        [JsonProperty("months")]
        public float[] Months { get; set; }
    }
}
