using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TravelPlanner.Core.Flights;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Flight
    {
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
