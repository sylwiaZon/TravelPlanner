
using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class TransportLocation
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Distance { get; set; }

        [DataMember]
        public string DistanceInTime { get; set; }
    }
}
