using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TravelPlanner.Core.Flights.Converter
{
    class FlightsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<Flight[]>();
            }
            return new Flight[] { token.ToObject<Flight>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
