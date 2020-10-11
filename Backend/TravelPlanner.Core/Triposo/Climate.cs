using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class Climate
    {
        [JsonProperty("temperature")]
        public ClimateTemperature Temperature { get; set; }
    }
}
