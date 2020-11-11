using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class ItineraryItem
    {
        [DataMember]
        public string ItineraryItemId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}
