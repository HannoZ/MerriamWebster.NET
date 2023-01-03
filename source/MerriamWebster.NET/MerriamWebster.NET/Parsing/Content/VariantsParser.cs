using System;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class VariantsParser : IContentParser
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

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (source.Variants.HasValue())
            {
                target.Variants = VariantHelper.Parse(source.Variants, target.Metadata.Language, options.AudioFormat).ToList();
            }

            return target;
        }
    }
}