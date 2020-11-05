using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class TravelDestination
    {
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Country { get; set; }
    }
}
