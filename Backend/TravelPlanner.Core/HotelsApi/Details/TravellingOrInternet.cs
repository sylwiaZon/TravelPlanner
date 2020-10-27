using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class TravellingOrInternet
    {
        [JsonProperty("travelling")]
        public Travelling Travelling { get; set; }

        [JsonProperty("internet")]
        public string[] Internet { get; set; }
    }
}
