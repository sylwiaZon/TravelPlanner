using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class ImageAttribution
    {
        [JsonProperty("attribution_link")]
        public string AttributionLink { get; set; }

        [JsonProperty("attribution_text")]
        public string AttributionText { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("license_link")]
        public string LicenseLink { get; set; }

        [JsonProperty("license_text")]
        public string LicenseText { get; set; }
    }
}
