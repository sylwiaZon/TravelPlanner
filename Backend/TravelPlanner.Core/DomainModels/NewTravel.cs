using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class NewTravel
    {
        [DataMember]
        public string TravelIdentity { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public TravelParticipants Participants { get; set; }

        [DataMember]
        public TravelDestination TravelDestination { get; set; }
    }
}
