using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DefiningTextComplexTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefiningTextComplexType) || t == typeof(DefiningTextComplexType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DefiningTextComplexType { TypeOrLabel = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DefiningText>(reader);
                    return new DefiningTextComplexType { DefiningTextClass = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningText[]>(reader);
                    return new DefiningTextComplexType { DtClassArray = arrayValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type DefiningTextComplexType. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextComplexType)untypedValue;
            if (value.TypeOrLabel != null)
            {
                serializer.Serialize(writer, value.TypeOrLabel);
                return;
            }
            if (value.DtClassArray != null)
            {
                serializer.Serialize(writer, value.DtClassArray);
                return;
            }
            if (value.DefiningTextClass != null)
            {
                serializer.Serialize(writer, value.DefiningTextClass);
                return;
            }
            throw new NotImplementedException("Cannot marshal type DefiningTextComplexType");
        }

        public static readonly DefiningTextComplexTypeConverter Singleton = new DefiningTextComplexTypeConverter();
    }
}