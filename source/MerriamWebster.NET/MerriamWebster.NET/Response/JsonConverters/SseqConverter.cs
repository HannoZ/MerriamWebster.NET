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
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<SenseSequence[][]>(reader);
                    return new SenseSequence { SenseSequences = arrayValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type Sense. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SenseSequence)untypedValue;

            if (value.Sense != null)
            {
                serializer.Serialize(writer, value.Sense);
                return;
            }
            throw new NotImplementedException("Cannot marshal type Sense");
        }

        public static readonly SseqConverter Singleton = new SseqConverter();
    }
}
