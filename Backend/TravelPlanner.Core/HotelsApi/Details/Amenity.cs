using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Amenity
    {
        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("listItems")]
        public ListItem[] ListItems { get; set; }
    }
}
