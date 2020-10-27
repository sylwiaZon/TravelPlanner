using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Details
{
    public class Error
    {
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("errorMessages")]
        public string[] ErrorMessages { get; set; }
    }
}
