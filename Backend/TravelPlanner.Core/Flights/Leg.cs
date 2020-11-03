using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Leg
    {
        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }

        [JsonProperty("origin ")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("aircraftOwner")]
        public string AircraftOwner { get; set; }

        [JsonProperty("aircraftType")]
        public string AircraftType { get; set; }

        [JsonProperty("aircraftConfigurationVersion")]
        public string AircraftConfigurationVersion { get; set; }

        [JsonProperty("registration")]
        public string Registration { get; set; }

        [JsonProperty("op")]
        public bool Op { get; set; }

        [JsonProperty("aircraftDepartureTimeUTC")]
        public int AircraftDepartureTimeUTC { get; set; }

        [JsonProperty("aircraftDepartureTimeDateDiffUTC")]
        public int AircraftDepartureTimeDateDiffUTC { get; set; }

        [JsonProperty("aircraftDepartureTimeLT")]
        public int AircraftDepartureTimeLT { get; set; }

        [JsonProperty("aircraftDepartureTimeDateDiffLT")]
        public int AircraftDepartureTimeDateDiffLT { get; set; }

        [JsonProperty("aircraftDepartureTimeVariation")]
        public int AircraftDepartureTimeVariation { get; set; }

        [JsonProperty("aircraftArrivalTimeUTC")]
        public int AircraftArrivalTimeUTC { get; set; }

        [JsonProperty("aircraftArrivalTimeDateDiffUTC")]
        public int AircraftArrivalTimeDateDiffUTC { get; set; }

        [JsonProperty("aircraftArrivalTimeLT")]
        public int AircraftArrivalTimeLT { get; set; }

        [JsonProperty("aircraftArrivalTimeDateDiffLT")]
        public int AircraftArrivalTimeDateDiffLT { get; set; }

        [JsonProperty("aircraftArrivalTimeVariation")]
        public int AircraftArrivalTimeVariation { get; set; }
    }
}
