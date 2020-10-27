using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Data
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("common")]
        public Common Common { get; set; }
    }
}
