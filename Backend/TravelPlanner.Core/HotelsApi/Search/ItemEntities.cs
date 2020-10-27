using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Search
{
    public class ItemEntities
    {
        [JsonProperty("geoId")]
        public string GeoId { get; set; }

        [JsonProperty("destinationId")]
        public string DestinationId { get; set; }

        [JsonProperty("landmarkCityDestinationId")]
        public string LandmarkCityDestinationId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("redirectPage")]
        public string RedirectPage { get; set; }

        [JsonProperty("latitude")]
        public int Latitude { get; set; }

        [JsonProperty("longitude")]
        public int Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
