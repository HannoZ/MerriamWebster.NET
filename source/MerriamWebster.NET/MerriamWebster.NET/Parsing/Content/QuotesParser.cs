using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using Quote = MerriamWebster.NET.Results.Quote;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class QuotesParser : IContentParser
    {
        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (!source.Quotes.HasValue())
            {
                return;
            }

            //target.Quotes = new List<Quote>();

            //foreach (var sourceQuote in source.Quotes)
            //{
            //    var quote = QuoteHelper.ParseMultiple(sourceQuote);
            //    target.Quotes.Add(quote);
            //}

        }
    }
}