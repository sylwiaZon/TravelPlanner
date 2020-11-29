

using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class HotelTransport
    {
        [DataMember]
        public string Category { get; set; }
    }
}
