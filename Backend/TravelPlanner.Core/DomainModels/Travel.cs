using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TravelPlanner.Core.Triposo;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Travel
    {
        [JsonProperty("identity")]
        public int Identity { get; set; }

        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public TravelParticipants Participants { get; set; }

        [DataMember]
        public TravelDestination TravelDestination { get; set; }

        [DataMember]
        public Flight Flight{ get; set; }

        [DataMember]
        public Hotel Hotel{ get; set; }

        [DataMember]
        public List<ToDoItem> ToDoList { get; set; } 

        [DataMember]
        public List<ToSeeItem> ToSeeList { get; set; } 

        [DataMember]
        public List<CityWalk> CityWalks { get; set; } 

        [DataMember]
        public List<DayPlan> DayPlans { get; set; }

        [DataMember]
        public Location LocationInfo { get; set; }

        [DataMember]
        public List<Tour> Tours { get; set; } 

        [DataMember]
        public List<LocalHighlights> LocalHighlights { get; set; }
    }
}
