using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class ListItem
    {
        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("listItems")]
        public string[] ListItems { get; set; }
    }
}
