using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DtUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefiningTextObject) || t == typeof(DefiningTextObject?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DefiningTextObject { TypeOrText = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningText[]>(reader);
                    return new DefiningTextObject { DefiningTextArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type DefiningTextObject");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextObject)untypedValue;
            if (value.TypeOrText != null)
            {
                serializer.Serialize(writer, value.TypeOrText);
                return;
            }
            if (value.DefiningTextArray != null)
            {
                serializer.Serialize(writer, value.DefiningTextArray);
                return;
            }
            throw new Exception("Cannot marshal type DefiningTextObject");
        }

        public static readonly DtUnionConverter Singleton = new DtUnionConverter();
    }
}