using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class Precipitation
    {
        [JsonProperty("3h")]
        public double Volume { get; set; }
    }
}
