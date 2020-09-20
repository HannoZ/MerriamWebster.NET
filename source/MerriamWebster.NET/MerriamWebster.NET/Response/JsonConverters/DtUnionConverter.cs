using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DtUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TranslationObject) || t == typeof(TranslationObject?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new TranslationObject { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<TranslationClass[]>(reader);
                    return new TranslationObject { TranslationClassArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type TranslationObject");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (TranslationObject)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.TranslationClassArray != null)
            {
                serializer.Serialize(writer, value.TranslationClassArray);
                return;
            }
            throw new Exception("Cannot marshal type TranslationObject");
        }

        public static readonly DtUnionConverter Singleton = new DtUnionConverter();
    }
}