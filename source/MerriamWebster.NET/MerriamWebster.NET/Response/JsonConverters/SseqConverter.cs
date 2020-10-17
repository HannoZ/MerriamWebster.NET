using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SseqConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SenseSequence) || t == typeof(SenseSequence?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new SenseSequence { Name = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<Sense>(reader);
                    return new SenseSequence { Sense = objectValue };
            }
            throw new Exception("Cannot unmarshal type Sense");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SenseSequence)untypedValue;

            if (value.Sense != null)
            {
                serializer.Serialize(writer, value.Sense);
                return;
            }
            throw new Exception("Cannot marshal type Sense");
        }

        public static readonly SseqConverter Singleton = new SseqConverter();
    }
}
