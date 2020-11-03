using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Flight
    {
        [JsonProperty("Departure")]
        public AirportFlightStatus Departure { get; set; }

        [JsonProperty("Arrival")]
        public AirportFlightStatus Arrival { get; set; }

        [JsonProperty("MarketingCarrier")]
        public Carrier MarketingCarrier { get; set; }

        [JsonProperty("OperatingCarrier")]
        public Carrier OperatingCarrier { get; set; }

        [JsonProperty("Equipment")]
        public Equipment Equipment { get; set; }

        [JsonProperty("FlightStatus")]
        public FlightStatus FlightStatus { get; set; }

        [JsonProperty("ServiceType")]
        public string ServiceType { get; set; }

        [JsonProperty("Details")]
        public Details Details { get; set; }
    }
}
