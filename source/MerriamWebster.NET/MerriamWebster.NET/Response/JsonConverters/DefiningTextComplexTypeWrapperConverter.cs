using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DefiningTextComplexTypeWrapperConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefiningTextComplexTypeWrapper) || t == typeof(DefiningTextComplexTypeWrapper?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DefiningTextComplexTypeWrapper { TypeLabelOrText = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<RunInWrap>(reader);
                    return new DefiningTextComplexTypeWrapper { RunInWrap = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningTextComplexType[]>(reader);
                    return new DefiningTextComplexTypeWrapper { DefiningTextComplexTypes = arrayValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type DefiningTextComplexTypeWrapper. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextComplexTypeWrapper)untypedValue;
            if (value.TypeLabelOrText != null)
            {
                serializer.Serialize(writer, value.TypeLabelOrText);
                return;
            }
            if (value.DefiningTextComplexTypes != null)
            {
                serializer.Serialize(writer, value.DefiningTextComplexTypes);
                return;
            }
            throw new NotImplementedException("Cannot marshal type DefiningTextComplexTypeWrapper");
        }

        public static readonly DefiningTextComplexTypeWrapperConverter Singleton = new DefiningTextComplexTypeWrapperConverter();
    }
}