using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class Itinerary
    {
        [DataMember]
        public string ItineraryId { get; set; }

        [DataMember]
        public string Date { get; set; }
    }
}
