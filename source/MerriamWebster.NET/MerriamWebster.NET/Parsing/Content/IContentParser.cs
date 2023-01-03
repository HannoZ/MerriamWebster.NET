using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    public interface IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options);
    }
}
