using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Compartment
    {
        [JsonProperty("ClassCode")]
        public string ClassCode { get; set; }

        [JsonProperty("ClassDesc")]
        public string ClassDesc { get; set; }

        [JsonProperty("FlyNet")]
        public string FlyNet { get; set; }

        [JsonProperty("SeatPower")]
        public string SeatPower { get; set; }

        [JsonProperty("Usb")]
        public string Usb { get; set; }

        [JsonProperty("LiveTv")]
        public string LiveTv { get; set; }
    }
}
