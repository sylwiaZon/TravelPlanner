using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Airport
    {
        [DataMember]
        public string AirportCode { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public string CityCode { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string LocationType { get; set; }

        [DataMember]
        public string[] Names { get; set; }

        [DataMember]
        public float DistanceValue { get; set; }

        [DataMember]
        public string DistanceUnit { get; set; }
    }
}
