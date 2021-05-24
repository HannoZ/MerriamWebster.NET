using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MerriamWebster.NET.Response.JsonConverters
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
                DefiningTextComplexTypeConverter.Singleton,
                DefiningTextComplexTypeWrapperConverter.Singleton,
                DefiningTextObjectConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
