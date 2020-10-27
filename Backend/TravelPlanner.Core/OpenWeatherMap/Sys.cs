using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
