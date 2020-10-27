using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class WeatherForecastApi
    {
        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("message")]
        public int Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public WeatherList[] List { get; set; }
    }
}
