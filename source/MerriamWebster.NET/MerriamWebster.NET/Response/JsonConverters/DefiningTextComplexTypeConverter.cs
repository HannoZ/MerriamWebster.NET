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
                    return new DefiningTextComplexType { DefiningText = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningText[]>(reader);
                    return new DefiningTextComplexType { DefiningTexts = arrayValue };
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
            if (value.DefiningTexts != null)
            {
                serializer.Serialize(writer, value.DefiningTexts);
                return;
            }
            if (value.DefiningText != null)
            {
                serializer.Serialize(writer, value.DefiningText);
                return;
            }
            throw new NotImplementedException("Cannot marshal type DefiningTextComplexType");
        }

        public static readonly DefiningTextComplexTypeConverter Singleton = new DefiningTextComplexTypeConverter();
    }
}