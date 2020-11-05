using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class NewTravel
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public TravelParticipants Participants { get; set; }

        [DataMember]
        public TravelDestination TravelDestination { get; set; }
    }
}
