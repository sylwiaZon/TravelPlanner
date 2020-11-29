using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class HotelTransport
    {
        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public TransportLocation[] TransportLocations { get; set; }
    }
}
