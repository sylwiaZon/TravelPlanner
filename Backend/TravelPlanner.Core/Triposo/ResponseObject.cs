using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelPlanner.Core.Triposo
{
    public class ResponseObject<T> 
    {
        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
