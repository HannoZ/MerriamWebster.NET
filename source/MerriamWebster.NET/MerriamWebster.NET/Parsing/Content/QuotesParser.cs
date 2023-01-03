using System;
using System.Collections.Generic;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class QuotesParser : IContentParser
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

            if (!source.Quotes.HasValue())
            {
                return target;
            }

            target.Quotes = new List<Dto.Quote>();

            foreach (var sourceQuote in source.Quotes)
            {
                var quote = QuoteHelper.Parse(sourceQuote);
                target.Quotes.Add(quote);
            }

            return target;
        }
    }
}