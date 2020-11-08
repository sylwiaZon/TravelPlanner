using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelPlanner.Core.Flights
{
    public class Coordinate
    {
        [JsonProperty("Latitude")]
        public float Latitude { get; set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; set; }

    }
}
