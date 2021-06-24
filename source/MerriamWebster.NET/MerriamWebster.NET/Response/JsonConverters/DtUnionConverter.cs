using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DtUnionConverter : JsonConverter
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
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningTextObject[]>(reader);
                    return new DefiningTextObjectWrapper { DefiningTextArray = arrayValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<CalledAlso>(reader);
                    return new DefiningTextObjectWrapper {CalledAlso = objectValue};

            }
            throw new Exception("Cannot unmarshal type DefiningTextObjectWrapper");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextObjectWrapper)untypedValue;
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
            throw new Exception("Cannot marshal type DefiningTextObjectWrapper");
        }

        public static readonly DtUnionConverter Singleton = new DtUnionConverter();
    }
}