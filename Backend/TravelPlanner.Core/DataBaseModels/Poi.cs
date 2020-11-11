using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Poi
    {
        [DataMember]
        public string PoiId { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public float? Latitude { get; set; }

        [DataMember]
        public float? Longitude { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Intro { get; set; }

        [DataMember]
        public string LocationId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public float? Score { get; set; }

        [DataMember]
        public string Snippet { get; set; }
    }
}
