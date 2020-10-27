using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class HotelBadge
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("tooltipTitle")]
        public string TooltipTitle { get; set; }

        [JsonProperty("tooltipText")]
        public string TooltipText { get; set; }
    }
}
