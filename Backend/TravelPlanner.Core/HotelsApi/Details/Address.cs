using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Address
    {
        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("provinceName")]
        public string ProvinceName { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("fullAddress")]
        public string Fulladdress { get; set; }
    }
}
