﻿using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class NewTravel
    {
        [DataMember]
        public string TravelId { get; set; }

        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public TravelParticipants Participants { get; set; }

        [DataMember]
        public TravelDestination TravelDestination { get; set; }
    }
}
