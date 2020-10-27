using Newtonsoft.Json;

namespace TravelPlanner.Core.OpenWeatherMap
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coordinates Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }
    }
}
