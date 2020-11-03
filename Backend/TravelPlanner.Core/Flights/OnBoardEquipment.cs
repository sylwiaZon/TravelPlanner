using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class OnBoardEquipment
    {
        [JsonProperty("InflightEntertainment")]
        public bool InflightEntertainment { get; set; }

        [JsonProperty("Compartment")]
        public Compartment Compartment { get; set; }
    }
}
