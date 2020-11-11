using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class WayPoint
    {
        [DataMember]
        public string WayPointId { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public int VisitTime { get; set; }

        [DataMember]
        public int WalkToNextDistance { get; set; }

        [DataMember]
        public int WalkToNextDuration { get; set; }
    }
}
