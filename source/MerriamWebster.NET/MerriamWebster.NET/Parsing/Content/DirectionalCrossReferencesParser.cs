using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class DirectionalCrossReferencesParser : IContentParser
    {
        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (!source.DirectionalCrossReferences.HasValue())
            {
                return;
            }
         
            //target.DirectionalCrossReferences = new List<FormattedText>();
            //foreach (var crossReference in source.DirectionalCrossReferences)
            //{
            //    target.DirectionalCrossReferences.Add(new FormattedText(crossReference));
            //}

        }
    }
}