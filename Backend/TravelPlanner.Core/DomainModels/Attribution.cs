using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Attribution
    {
        [DataMember]
        public string Url { get; set; }
        
        [DataMember]
        public string Source { get; set; }
    }
}
