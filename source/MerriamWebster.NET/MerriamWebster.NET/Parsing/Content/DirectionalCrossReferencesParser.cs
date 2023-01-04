using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class DirectionalCrossReferencesParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (!source.DirectionalCrossReferences.HasValue())
            {
                return target;
            }
         
            target.DirectionalCrossReferences = new List<FormattedText>();
            foreach (var crossReference in source.DirectionalCrossReferences)
            {
                target.DirectionalCrossReferences.Add(new FormattedText(crossReference));
            }

            return target;
        }
    }
}