using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class TravelParticipants
    {
        [DataMember]
        public int Children { get; set; }

        [DataMember]
        public int[] ChildrenAges { get; set; }

        [DataMember]
        public int Adults { get; set; }
    }
}
