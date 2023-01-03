using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class EtymologyParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source.Et.HasValue())
            {
                target.Etymology = source.Et.ParseEtymology();
            }

            return target;
        }
    }
}