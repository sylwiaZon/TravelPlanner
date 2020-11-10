using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public string HotelId { get; set; }

        [DataMember]
        public string GeoId { get; set; }

        [DataMember]
        public string DestinationId { get; set; }

        [DataMember]
        public string LandmarkCityDestinationId { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public string RedirectPage { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
