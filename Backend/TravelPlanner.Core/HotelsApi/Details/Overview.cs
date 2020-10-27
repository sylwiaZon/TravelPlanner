using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Overview
    {
        [JsonProperty("overwievSection")]
        public OverViewSection[] OverViewSection { get; set; }
    }
}
