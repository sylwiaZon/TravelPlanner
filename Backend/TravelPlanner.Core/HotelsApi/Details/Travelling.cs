using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Travelling
    {
        [JsonProperty("children")]
        public string[] Children { get; set; }

        [JsonProperty("pets")]
        public string[] Pets { get; set; }

        [JsonProperty("extraPeople")]
        public string[] ExtraPeople { get; set; }
    }
}
