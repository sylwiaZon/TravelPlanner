using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class WeatherList
    {
        [JsonProperty("dt")]
        public int Date { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("pop")]
        public double PrecipitationProbability { get; set; }

        [JsonProperty("rain")]
        public Precipitation Rain { get; set; }

        [JsonProperty("snow")]
        public Precipitation Snow { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string DateText { get; set; }
    }
}
