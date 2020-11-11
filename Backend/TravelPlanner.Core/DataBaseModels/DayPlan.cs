using System.Runtime.Serialization;

namespace TravelPlanner.Core.DataBaseModels
{
    [DataContract]
    public class DayPlan
    {
        [DataMember]
        public string DayPlanId { get; set; }
    }
}
