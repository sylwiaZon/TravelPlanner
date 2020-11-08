using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Airport
    {
        [JsonProperty("AirportCode")]
        public string AirportCode { get; set; }

        [JsonProperty("Position")]
        public Position Position { get; set; }

        [JsonProperty("CityCode")]
        public string CityCode { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("LocationType")]
        public string LocationType { get; set; }

        [JsonProperty("Names")]
        public Names Names { get; set; }

        [JsonProperty("Distance")]
        public Distance Distance { get; set; }
    }
}
