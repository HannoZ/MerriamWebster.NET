using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.Content
{
    public interface IContentParser
    {
        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options);
    }
}
