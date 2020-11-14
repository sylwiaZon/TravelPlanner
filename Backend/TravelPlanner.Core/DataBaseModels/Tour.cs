using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Tour
    {
        [DataMember]
        public string Price{ get; set; }

        [DataMember]
        public string PriceCurrency { get; set; }

        [DataMember]
        public string Vendor { get; set; }

        [DataMember]
        public string VendorTourUrl { get; set; }

        [DataMember]
        public float? Duartion { get; set; }

        [DataMember]
        public string DurationUnit { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Intro { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
