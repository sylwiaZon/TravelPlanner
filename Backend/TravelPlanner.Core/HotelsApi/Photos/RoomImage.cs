using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Photos
{
    public class RoomImage
    {
        [JsonProperty("roomId")]
        public long HotelId { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }
}
