using Newtonsoft.Json;
using TravelPlanner.Core.Flights.Converter;

namespace TravelPlanner.Core.Flights
{
    public class Schedule
    {
        [JsonProperty("TotalJourney")]
        public TotalJourney TotalJourney { get; set; }

        [JsonProperty("Flight")]
        [JsonConverter(typeof(FlightsConverter))]
        public Flight[] Flight { get; set; }
    }
}
