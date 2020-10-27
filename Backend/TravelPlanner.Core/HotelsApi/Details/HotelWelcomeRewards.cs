using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HotelWelcomeRewards
    {
        [JsonProperty("applies")]
        public bool Applies { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }
    }
}
