using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class Equipment
    {
        [JsonProperty("AircraftCode")]
        public string AircraftCode { get; set; }

        [JsonProperty("OnBoardEquipment")]
        public OnBoardEquipment OnBoardEquipment { get; set; }
    }
}
