using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class FlightSchedule
    {
        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("flightNumber")]
        public int FlightNumber { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("periodOfOperationUTC")]
        public PeriodOfOperation PeriodOfOperationUTC { get; set; }

        [JsonProperty("periodOfOperationLT")]
        public PeriodOfOperation PeriodOfOperationLT { get; set; }

        [JsonProperty("legs")]
        public Leg[] Legs { get; set; }

        [JsonProperty("dataElements")]
        public DataElement[] DataElements { get; set; }
    }
}
