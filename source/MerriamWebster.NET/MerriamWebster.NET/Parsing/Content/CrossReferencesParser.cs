using System;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class CrossReferencesParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.CrossReferences.Any())
            {
                target.CrossReferences = CrossReferenceHelper.Parse(source.CrossReferences).ToList();
            }

            return target;

        }
    }
}