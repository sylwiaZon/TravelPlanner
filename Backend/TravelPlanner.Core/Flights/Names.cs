using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Names
    {
        [JsonProperty("Name")]
        public Name[] Name { get; set; }
    }
}
