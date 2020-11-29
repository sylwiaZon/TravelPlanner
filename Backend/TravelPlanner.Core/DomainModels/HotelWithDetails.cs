using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class HotelWithDetails
    {
        [DataMember]
        public Hotel Hotel { get; set; }

        [DataMember]
        public IEnumerable<HotelTransport> Transport { get; set; }
    }
}
