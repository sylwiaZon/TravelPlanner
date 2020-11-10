using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Poi
    {
        [DataMember]
        public string SourceID { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Intro { get; set; }

        [DataMember]
        public string LocationId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public float Score { get; set; }

        [DataMember]
        public string Snippet { get; set; }
    }
}
