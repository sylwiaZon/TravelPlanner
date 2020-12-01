using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class ToSeeItem
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public bool Checked { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Poi Poi { get; set; }
    }
}
