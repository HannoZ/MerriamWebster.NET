using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    public interface IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options);
    }
}
