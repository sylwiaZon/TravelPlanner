using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class ItineraryItem
    { 
        [DataMember]
        public string ItineraryItemId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Poi Poi { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}
