using System;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class CrossReferencesParser : IContentParser
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

            if (source.CrossReferences.Any())
            {
                target.CrossReferences = CrossReferenceHelper.Parse(source.CrossReferences).ToList();
            }

            return target;

        }
    }
}