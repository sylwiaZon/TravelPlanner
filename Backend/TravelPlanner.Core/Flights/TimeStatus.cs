﻿using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class TimeStatus
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Definition")]
        public string Definition { get; set; }
    }
}
