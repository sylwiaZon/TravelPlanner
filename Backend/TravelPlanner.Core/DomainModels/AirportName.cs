using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class AirportName
    {
        [DataMember]
        public string LanguageCode { get; set; }

        [DataMember]
        public string WholeName { get; set; }
    }
}
