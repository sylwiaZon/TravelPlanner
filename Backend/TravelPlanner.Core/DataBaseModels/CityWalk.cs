using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class CityWalk
    {
        [DataMember]
        public string CityWalkId { get; set; }

        [DataMember]
        public int Seed { get; set; }

        [DataMember]
        public int TotalDuration { get; set; }

        [DataMember]
        public int WalkDistance { get; set; }

        [DataMember]
        public int WalkDuration { get; set; }
    }
}
