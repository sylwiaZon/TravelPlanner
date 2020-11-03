using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Terminal
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
