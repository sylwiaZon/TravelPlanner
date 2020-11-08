using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Name
    {
        [JsonProperty("@LanguageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("$")]
        public string WholeName { get; set; }
    }
}
