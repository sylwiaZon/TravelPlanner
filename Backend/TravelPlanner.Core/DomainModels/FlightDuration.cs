using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class FlightDuration
    {
        [DataMember]
        public int Days { get; set; }

        [DataMember]
        public int Hours { get; set; }

        [DataMember]
        public int Minutes { get; set;  }
    }
}
