using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class BookingInfo
    {
        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("vendor_object_id")]
        public string VendorObjectId { get; set; }

        [JsonProperty("vendor_object_url")]
        public string[] VendorObjectUrl { get; set; }
    }
}
