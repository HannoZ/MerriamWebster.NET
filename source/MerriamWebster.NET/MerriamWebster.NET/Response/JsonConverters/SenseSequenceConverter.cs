using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SenseSequenceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SenseSequence) || t == typeof(SenseSequence?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "bs":
                            return new SenseSequence { Name = SseqEnum.Bs };
                        case "pseq":
                            return new SenseSequence { Name = SseqEnum.Pseq };
                        case "sen":
                            return new SenseSequence { Name = SseqEnum.Sen };
                        case "sense":
                            return new SenseSequence { Name = SseqEnum.Sense };
                    }

                    break;
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<Sense>(reader);
                    return new SenseSequence { Sense = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<SenseSequence[][]>(reader);
                    return new SenseSequence { SenseSequences = arrayValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type SenseSequence. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SenseSequence)untypedValue;
            if (value.Name != null)
            {
                switch (value.Name)
                {
                    case SseqEnum.Bs:
                        serializer.Serialize(writer, "bs");
                        return;
                    case SseqEnum.Pseq:
                        serializer.Serialize(writer, "pseq");
                        return;
                    case SseqEnum.Sen:
                        serializer.Serialize(writer, "sen");
                        return;
                    case SseqEnum.Sense:
                        serializer.Serialize(writer, "sense");
                        return;
                }
            }
            if (value.SenseSequences != null)
            {
                serializer.Serialize(writer, value.SenseSequences);
                return;
            }
            if (value.Sense != null)
            {
                serializer.Serialize(writer, value.Sense);
                return;
            }

            throw new NotImplementedException("Cannot marshal type SenseSequence");
        }

        public static readonly SenseSequenceConverter Singleton = new SenseSequenceConverter();
    }
}
