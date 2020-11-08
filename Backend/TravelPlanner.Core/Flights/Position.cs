using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Position
    {
        [JsonProperty("Coordinate")]
        public Coordinate Coordinate { get; set; }
    }
}
