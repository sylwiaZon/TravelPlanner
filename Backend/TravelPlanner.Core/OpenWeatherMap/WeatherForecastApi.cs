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
            public string DateText{ get; set; }
        }

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

        public class Weather
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public class City
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name{ get; set; }

            [JsonProperty("coord")]
            public Coordinates Coord { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("timezone")]
            public int Timezone { get; set; }
        }

        public class Coordinates
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lon")]
            public double Lon { get; set; }
        }

        public class Clouds
        {
            [JsonProperty("all")]
            public int All { get; set; }
        }

        public class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public double Deg { get; set; }
        }

        public class Precipitation
        {
            [JsonProperty("3h")]
            public double Volume { get; set; }
        }

        public class Sys
        {
            [JsonProperty("pod")]
            public string Pod { get; set; }
        }
    }
}
