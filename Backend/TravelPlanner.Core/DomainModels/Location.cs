using System.Runtime.Serialization;
using TriposoLocation = TravelPlanner.Core.Triposo.Location;
using DBLocation = TravelPlanner.Core.DataBaseModels.Location;
using System;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public string LocationId { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public string CountryId { get; set; }

        [DataMember]
        public string Intro { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string[] Names { get; set; }

        [DataMember]
        public string ParentId { get; set; }

        [DataMember]
        public string[] PartOf { get; set; }

        [DataMember]
        public float Score { get; set; }

        [DataMember]
        public string Snippet { get; set; }

        [DataMember]
        public string[] TagLabels { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }
    }
}
