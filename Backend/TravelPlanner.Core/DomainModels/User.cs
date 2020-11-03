﻿using System.Runtime.Serialization;

namespace TravelPlanner.Core
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Mail { get; set; }
    }
}
