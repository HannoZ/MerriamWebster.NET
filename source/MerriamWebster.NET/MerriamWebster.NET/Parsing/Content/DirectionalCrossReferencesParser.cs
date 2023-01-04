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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

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