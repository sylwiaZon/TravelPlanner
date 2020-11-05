using System.Runtime.Serialization;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class ToDoItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Checked { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
