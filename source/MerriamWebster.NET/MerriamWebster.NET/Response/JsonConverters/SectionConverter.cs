using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SectionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Section) || t == typeof(Section?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "alpha":
                    return Section.Alpha;
                case "biog":
                    return Section.Biog;
                case "geog":
                    return Section.Geog;
                case "idioms":
                    return Section.Idioms;
            }
            throw new Exception("Cannot unmarshal type Section");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Section)untypedValue;
            switch (value)
            {
                case Section.Alpha:
                    serializer.Serialize(writer, "alpha");
                    return;
                case Section.Biog:
                    serializer.Serialize(writer, "biog");
                    return;
                case Section.Geog:
                    serializer.Serialize(writer, "geog");
                    return;
                case Section.Idioms:
                    serializer.Serialize(writer, "idioms");
                    return;
            }
            throw new Exception("Cannot marshal type Section");
        }

        public static readonly SectionConverter Singleton = new SectionConverter();
    }
}