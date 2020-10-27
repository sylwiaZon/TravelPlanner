using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HotelLocation
    {
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }
}
