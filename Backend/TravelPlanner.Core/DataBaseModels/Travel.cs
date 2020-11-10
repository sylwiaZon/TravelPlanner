using System;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Travel
    {
        [DataMember]
        public string TravelId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Children { get; set; }

        [DataMember]
        public int[] ChildrenAges { get; set; }

        [DataMember]
        public int Adults { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Country { get; set; }
    }
}
