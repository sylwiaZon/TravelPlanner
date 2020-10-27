using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class PdpHeader
    {
        [JsonProperty("hotelId")]
        public string HotelId { get; set; }

        [JsonProperty("destinationId")]
        public string DestinationId { get; set; }

        [JsonProperty("pointOfSaleId")]
        public string PointOfSaleId { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("occupancyKey")]
        public string OccupancyKey { get; set; }

        [JsonProperty("hotelLocation")]
        public HotelLocation HotelLocation { get; set; }
    }
}
