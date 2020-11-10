using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class CityWalk
    {
        [DataMember]
        public int Seed { get; set; }

        [DataMember]
        public int TotalDuration { get; set; }

        [DataMember]
        public int WalkDistance { get; set; }

        [DataMember]
        public int WalkDuration { get; set; }

        [DataMember]
        public WayPoint[] WayPoints { get; set; }
    }
}
