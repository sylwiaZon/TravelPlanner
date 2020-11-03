using Newtonsoft.Json;

namespace TravelPlanner.Core.Flights
{
    public class DataElement
    {
        [JsonProperty("startLegSequenceNumber")]
        public int StartLegSequenceNumber { get; set; }

        [JsonProperty("endLegSequenceNumber")]
        public int EndLegSequenceNumber { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
