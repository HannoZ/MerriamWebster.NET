using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SseqConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SenseSequenceObject) || t == typeof(SenseSequenceObject?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new SenseSequenceObject { Name = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<SenseSequence>(reader);
                    return new SenseSequenceObject { SenseSequence = objectValue };
            }
            throw new Exception("Cannot unmarshal type SenseSequence");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SenseSequenceObject)untypedValue;

            if (value.SenseSequence != null)
            {
                serializer.Serialize(writer, value.SenseSequence);
                return;
            }
            throw new Exception("Cannot marshal type SenseSequence");
        }

        public static readonly SseqConverter Singleton = new SseqConverter();
    }
}
