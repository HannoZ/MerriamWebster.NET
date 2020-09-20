using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MerriamWebster.NET.Response.JsonConverters
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DtUnionConverter.Singleton,
                LangConverter.Singleton,
                SseqConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}