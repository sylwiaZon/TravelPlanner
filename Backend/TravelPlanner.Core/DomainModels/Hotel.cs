using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Search;

namespace TravelPlanner.Core.DomainModels
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public ItemEntities HotelData { get; set; }

        [DataMember]
        public HotelDetails HotelDetails { get; set; }
    }
}
