using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response.JsonConverters
{
    internal class SrcConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Source) || t == typeof(Source?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "coll_thes":
                    return Source.CollThes;
                case "collegiate":
                    return Source.Collegiate;
                case "int_dict":
                    return Source.IntDict;
                case "int_thes":
                    return Source.IntThes;
                case "ld":
                    return Source.Ld;
                case "learners":
                    return Source.Learners;
                case "medical":
                    return Source.Medical;
                case "sch_dict":
                    return Source.SchDict;
                case "sd2":
                    return Source.Sd2;
                case "spanish":
                    return Source.Spanish;
            }
            throw new Exception("Cannot unmarshal type Src");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Source)untypedValue;
            switch (value)
            {
                case Source.CollThes:
                    serializer.Serialize(writer, "coll_thes");
                    return;
                case Source.Collegiate:
                    serializer.Serialize(writer, "collegiate");
                    return;
                case Source.IntDict:
                    serializer.Serialize(writer, "int_dict");
                    return;
                case Source.IntThes:
                    serializer.Serialize(writer, "int_thes");
                    return;
                case Source.Ld:
                    serializer.Serialize(writer, "ld");
                    return;
                case Source.Learners:
                    serializer.Serialize(writer, "learners");
                    return;
                case Source.Medical:
                    serializer.Serialize(writer, "medical");
                    return;
                case Source.SchDict:
                    serializer.Serialize(writer, "sch_dict");
                    return;
                case Source.Sd2:
                    serializer.Serialize(writer, "sd2");
                    return;
                case Source.Spanish:
                    serializer.Serialize(writer, "spanish");
                    return;
            }
            throw new Exception("Cannot marshal type Src");
        }

        public static readonly SrcConverter Singleton = new SrcConverter();
    }
}