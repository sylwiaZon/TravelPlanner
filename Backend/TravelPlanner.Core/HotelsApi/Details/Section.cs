using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Section
    {
        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("freeText")]
        public string FreeText { get; set; }

        [JsonProperty("listItems")]
        public string[] ListItems { get; set; }

        [JsonProperty("subsections")]
        public string[] Subsections { get; set; }
    }
}
