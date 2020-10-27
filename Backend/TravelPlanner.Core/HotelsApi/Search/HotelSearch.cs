using Newtonsoft.Json;
using System.Threading;

namespace TravelPlanner.Core.HotelsApi.Search
{
    public class HotelSearch
    {
        [JsonProperty("properties")]
        public Properites Properites { get; set; }
    }
}
