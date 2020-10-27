using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
