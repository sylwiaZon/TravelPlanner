using System.Runtime.Serialization;

namespace TravelPlanner.Core
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }
    }
}
