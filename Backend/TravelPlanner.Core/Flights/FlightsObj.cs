using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class FlightsObj
    {
        [JsonProperty("Flight")]
        public Flight[] Flight { get; set; }
    }
}
