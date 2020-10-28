using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class KeyFacts
    {
        [JsonProperty("hotelSize")]
        public string[] HotelSize { get; set; }

        [JsonProperty("arrivingLeaving")]
        public string[] ArrivingLeaving { get; set; }

        [JsonProperty("specialCheckInstructions")]
        public string[] SpecialCheckInstructions { get; set; }

        [JsonProperty("requiredAtCheckin")]
        public string[] RequiredAtCheckIn { get; set; }
    }
}
