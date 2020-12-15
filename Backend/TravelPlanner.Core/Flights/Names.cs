using Newtonsoft.Json;
using System.Collections.Generic;
using TravelPlanner.Core.Flights.Converter;

namespace TravelPlanner.Core.Flights
{
    public class Names
    {
        [JsonProperty("Name")]
        [JsonConverter(typeof(AirportConverter))]
        public Name[] Name { get; set; }
    }
}
