using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class EtConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Etymology) || t == typeof(Etymology?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Etymology { TypeOrText = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<string[][]>(reader);
                    return new Etymology { Content = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Etymology");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Etymology)untypedValue;
            if (value.TypeOrText != null)
            {
                serializer.Serialize(writer, value.TypeOrText);
                return;
            }
            if (value.Content != null)
            {
                serializer.Serialize(writer, value.Content);
                return;
            }
            throw new Exception("Cannot marshal type Etymology");
        }

        public static readonly EtConverter Singleton = new EtConverter();
    }
}