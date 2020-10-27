using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HotelDetails
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("transportation")]
        public Transportation Transportation { get; set; }

        [JsonProperty("neighborhood")]
        public Neighborhood Neighborhood { get; set; }
    }
}