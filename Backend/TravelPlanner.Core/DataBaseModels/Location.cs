using System.Runtime.Serialization;
using DomainLocation = TravelPlanner.Core.DomainModels.Location;
using TriposoLocation = TravelPlanner.Core.Triposo.Location;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Location
    {
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

        public Location() { }

        public Location(DomainLocation domainLocation)
        {
            Latitude = domainLocation.Latitude;
            Longitude = domainLocation.Longitude;
            CountryId = domainLocation.CountryId;
            Intro = domainLocation.Intro;
            Name = domainLocation.Name;
            Names = domainLocation.Names;
            PartOf = domainLocation.PartOf;
            ParentId = domainLocation.ParentId;
            Score = domainLocation.Score;
            Snippet = domainLocation.Snippet;
            TagLabels = domainLocation.TagLabels;
            Type = domainLocation.Type;
        }

        public Location(TriposoLocation triposoLocation)
        {
            Latitude = triposoLocation.Coordinates.Latitude;
            Longitude = triposoLocation.Coordinates.Longitude;
            CountryId = triposoLocation.CountryId;
            Intro = triposoLocation.Intro;
            Name = triposoLocation.Name;
            Names = triposoLocation.Names;
            PartOf = triposoLocation.PartOf;
            ParentId = triposoLocation.ParentId;
            Score = triposoLocation.Score;
            Snippet = triposoLocation.Snippet;
            TagLabels = triposoLocation.TagLabels;
            Type = triposoLocation.Type;
        }
    }
}
