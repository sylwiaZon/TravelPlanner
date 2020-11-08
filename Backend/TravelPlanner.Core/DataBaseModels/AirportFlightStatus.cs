using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class AirportFlightStatus
    {
        [DataMember]
        public string AirportCode { get; set; }

        [DataMember]
        public DateTime ScheduledTimeLocal { get; set; }

        [DataMember]
        public string TerminalName { get; set; }
    }
}
