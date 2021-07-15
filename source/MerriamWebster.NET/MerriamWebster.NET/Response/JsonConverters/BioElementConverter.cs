using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class BioElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BioElement) || t == typeof(BioElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new BioElement { TypeOrText = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<BiographicalNote>(reader);
                    return new BioElement { BiographicalNote = objectValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type BioElement. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (BioElement)untypedValue;
            if (value.TypeOrText != null)
            {
                serializer.Serialize(writer, value.TypeOrText);
                return;
            }
            if (value.BiographicalNote != null)
            {
                serializer.Serialize(writer, value.BiographicalNote);
                return;
            }
            throw new NotImplementedException("Cannot marshal type BioElement");
        }

        public static readonly BioElementConverter Singleton = new BioElementConverter();
    }
}