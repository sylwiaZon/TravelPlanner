using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Flight
    {
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
    }
}
