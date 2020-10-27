using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("preassure")]
        public double Preassure { get; set; }

        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public double GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }
}
