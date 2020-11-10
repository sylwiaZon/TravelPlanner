using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class WayPoint
    {
        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public Poi Poi { get; set; }

        [DataMember]
        public int VistiTime { get; set; }

        [DataMember]
        public int WalkToNextDistance { get; set; }

        [DataMember]
        public int WalkToNextDuration { get; set; }
    }
}
