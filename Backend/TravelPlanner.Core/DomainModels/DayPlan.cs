using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class DayPlan
    {
        [DataMember]
        public string DayPlanId { get; set; }

        [DataMember]
        public Itinerary[] Days { get; set; }
    }
}
