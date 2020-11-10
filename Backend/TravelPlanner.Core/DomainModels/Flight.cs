using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public string FlightId { get; set; } 

        [DataMember]
        public FlightDuration FlightDuration { get; set; }

        [DataMember]
        public AirportFlightStatus Departure { get; set; }

        [DataMember]
        public AirportFlightStatus Arrival { get; set; }

        [DataMember]
        public string AirlineId { get; set; }
        
        [DataMember]
        public string FlightNumber { get; set; }
    }
}
