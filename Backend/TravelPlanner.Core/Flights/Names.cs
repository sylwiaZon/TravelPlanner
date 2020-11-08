using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Names
    {
        [JsonProperty("Names")]
        public Name[] Name { get; set; }
    }
}
