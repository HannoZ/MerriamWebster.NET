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
                BioElementConverter.Singleton,
                SseqEnumConverter.Singleton,
                DefiningTextObjectWrapperConverter.Singleton,
                LangConverter.Singleton,
                SenseSequenceConverter.Singleton,
                DefiningTextComplexTypeConverter.Singleton,
                DefiningTextComplexTypeWrapperConverter.Singleton,
                DefiningTextObjectConverter.Singleton,
                RefConverter.Singleton,
                EtConverter.Singleton,
                SectionConverter.Singleton,
                SrcConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
