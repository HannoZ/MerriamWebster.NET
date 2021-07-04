using System;
using System.Linq;
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
                    var obj = serializer.Deserialize(reader).ToString();
                    var canObj = JsonConvert.DeserializeObject<CalledAlsoNote>(obj);
                    if (canObj != null && !string.IsNullOrEmpty(canObj.Intro) && canObj.Targets.Any())
                    {
                        return new DefiningTextObjectWrapper { CalledAlso = canObj };
                    }

                    var bnwObj = JsonConvert.DeserializeObject<BiographicalNameWrap>(obj);
                    return new DefiningTextObjectWrapper {BiographicalNameWrap = bnwObj};
                    

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
            if (value.DefiningTextArray != null)
            {
                serializer.Serialize(writer, value.DefiningTextArray);
                return;
            }
            throw new NotImplementedException("Cannot marshal type DefiningTextObjectWrapper");
        }

        public static readonly DtUnionConverter Singleton = new DtUnionConverter();
    }
}