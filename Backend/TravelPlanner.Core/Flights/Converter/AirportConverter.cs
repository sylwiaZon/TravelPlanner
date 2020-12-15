using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TravelPlanner.Core.Flights.Converter
{
    class AirportConverter : JsonConverter
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
                return token.ToObject<Name[]>();
            }
            return new Name[] { token.ToObject<Name>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
