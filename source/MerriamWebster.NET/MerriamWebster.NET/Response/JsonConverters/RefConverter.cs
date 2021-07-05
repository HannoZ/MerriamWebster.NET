using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class RefConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Ref) || t == typeof(Ref?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "c":
                    return Ref.C;
                case "ld":
                    return Ref.Ld;
                case "owl":
                    return Ref.Owl;
                case "u":
                    return Ref.U;
            }
            throw new Exception("Cannot unmarshal type Ref");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Ref)untypedValue;
            switch (value)
            {
                case Ref.C:
                    serializer.Serialize(writer, "c");
                    return;
                case Ref.Ld:
                    serializer.Serialize(writer, "ld");
                    return;
                case Ref.Owl:
                    serializer.Serialize(writer, "owl");
                    return;
                case Ref.U:
                    serializer.Serialize(writer, "u");
                    return;
            }
            throw new Exception("Cannot marshal type Ref");
        }

        public static readonly RefConverter Singleton = new RefConverter();
    }
}