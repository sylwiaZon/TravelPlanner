using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Photos
{
    public class HotelPhotos
    {
        [JsonProperty("hotelId")]
        public long HotelId { get; set; }

        [JsonProperty("hotelImages")]
        public HotelImage[] HotelImages { get; set; }

        [JsonProperty("roomImages")]
        public RoomImage[] RoomImages { get; set; }

        [JsonProperty("featuredImageTrackingDetails")]
        public TrackingDetails FeaturedImageTrackingDetails { get; set; }

        [JsonProperty("propertyImageTrackingDetails")]
        public TrackingDetails PropertyImageTrackingDetails { get; set; }
    }
}
