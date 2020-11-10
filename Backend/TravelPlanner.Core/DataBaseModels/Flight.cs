using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public string FlightId { get; set;}

        [DataMember]
        public string AirlineId { get; set; }

        [DataMember]
        public string FlightNumber { get; set; }

        [DataMember]
        public int DurationDays { get; set; }

        [DataMember]
        public int DurationHours { get; set; }

        [DataMember]
        public int DurationMinutes { get; set; }

        [DataMember]
        public string ArrivalAirportCode { get; set; }

        [DataMember]
        public DateTime ArrivalScheduledTimeLocal { get; set; }

        [DataMember]
        public string ArrivalTerminalName { get; set; }

        [DataMember]
        public string DepartureAirportCode { get; set; }

        [DataMember]
        public DateTime DepartureScheduledTimeLocal { get; set; }

        [DataMember]
        public string DepartureTerminalName { get; set; }
    }
}
