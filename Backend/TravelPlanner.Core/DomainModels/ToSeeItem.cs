using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TravelPlanner.Core.Triposo;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class ToSeeItem
    {
        [DataMember]
        public bool OwnItem { get; set; }

        [DataMember]
        public bool Checked { get; set; }

        [DataMember]
        public bool Deleted { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Poi PointOfInterest { get; set; }
    }
}
