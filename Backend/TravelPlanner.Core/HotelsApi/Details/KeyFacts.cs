using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class KeyFacts
    {
        [JsonProperty("hotelSize")]
        public string[] HotelSize { get; set; }

        [JsonProperty("arrivingLeaving")]
        public KeyFacts ArrivingLeaving { get; set; }

        [JsonProperty("specialCheckInstructions")]
        public KeyFacts SpecialCheckInstructions { get; set; }

        [JsonProperty("requiredAtCheckin")]
        public KeyFacts RequiredAtCheckIn { get; set; }
    }
}
