using System;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class VariantsParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            if (source.Variants.HasValue())
            {
                target.Variants = VariantHelper.Parse(source.Variants, target.Metadata.Language, options.AudioFormat).ToList();
            }

            return target;
        }
    }
}