using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Search
{
    public class Item
    {
        [JsonProperty("items")]
        public ItemProperties Properties { get; set; }
    }
}
