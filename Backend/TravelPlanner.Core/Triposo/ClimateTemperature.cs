using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ClimateTemperature
    {
        [JsonProperty("average_max")]
        public ClimateStatistics AverageMax { get; set; }

        [JsonProperty("average_min")]
        public ClimateStatistics AverageMin { get; set; }
    }
}
