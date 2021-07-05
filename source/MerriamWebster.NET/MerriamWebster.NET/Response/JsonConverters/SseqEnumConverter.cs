using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SseqEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SseqEnum) || t == typeof(SseqEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bs":
                    return SseqEnum.Bs;
                case "pseq":
                    return SseqEnum.Pseq;
                case "sen":
                    return SseqEnum.Sen;
                case "sense":
                    return SseqEnum.Sense;
            }
            throw new Exception("Cannot unmarshal type SseqEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SseqEnum)untypedValue;
            switch (value)
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
            throw new Exception("Cannot marshal type SseqEnum");
        }

        public static readonly SseqEnumConverter Singleton = new SseqEnumConverter();
    }
}