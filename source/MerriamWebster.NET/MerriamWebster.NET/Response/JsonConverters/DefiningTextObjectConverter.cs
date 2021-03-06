﻿using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class DefiningTextObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DefiningTextObject) || t == typeof(DefiningTextObject?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DefiningText>(reader);
                    return new DefiningTextObject { DefiningText = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<DefiningTextComplexTypeWrapper[]>(reader);
                    return new DefiningTextObject { DefiningTextComplexTypeWrapperArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type DefiningTextObject");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DefiningTextObject)untypedValue;
            if (value.DefiningTextComplexTypeWrapperArray != null)
            {
                serializer.Serialize(writer, value.DefiningTextComplexTypeWrapperArray);
                return;
            }
            if (value.DefiningText != null)
            {
                serializer.Serialize(writer, value.DefiningText);
                return;
            }
            throw new Exception("Cannot marshal type DefiningTextObject");
        }

        public static readonly DefiningTextObjectConverter Singleton = new DefiningTextObjectConverter();
    }
}