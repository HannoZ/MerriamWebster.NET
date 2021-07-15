using System;
using System.Linq;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DefiningTextObjectWrapperConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefiningTextObjectWrapper) || t == typeof(DefiningTextObjectWrapper?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DefiningTextObjectWrapper { TypeOrText = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DefiningText>(reader);
                    return new DefiningTextObjectWrapper { DefiningText = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningTextObject[]>(reader);
                    return new DefiningTextObjectWrapper { DefiningTextObjects = arrayValue };
            }
            throw new NotImplementedException($"Cannot unmarshal type DefiningTextObjectWrapper. Path: {reader.Path}, TokenType: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextObjectWrapper)untypedValue;
            if (value.TypeOrText != null)
            {
                serializer.Serialize(writer, value.TypeOrText);
                return;
            }
            if (value.DefiningTextObjects != null)
            {
                serializer.Serialize(writer, value.DefiningTextObjects);
                return;
            }
            if (value.DefiningText != null)
            {
                serializer.Serialize(writer, value.DefiningText);
                return;
            }

            throw new NotImplementedException("Cannot marshal type DefiningTextObjectWrapper");
        }

        public static readonly DefiningTextObjectWrapperConverter Singleton = new DefiningTextObjectWrapperConverter();
    }
}