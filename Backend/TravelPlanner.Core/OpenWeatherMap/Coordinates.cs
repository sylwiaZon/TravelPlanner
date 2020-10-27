using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }
}
