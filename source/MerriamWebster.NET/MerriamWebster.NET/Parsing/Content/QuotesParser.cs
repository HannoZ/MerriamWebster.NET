﻿using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Quote = MerriamWebster.NET.Results.Quote;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class QuotesParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (!source.Quotes.HasValue())
            {
                return target;
            }

            target.Quotes = new List<Quote>();

            foreach (var sourceQuote in source.Quotes)
            {
                var quote = QuoteHelper.Parse(sourceQuote);
                target.Quotes.Add(quote);
            }

            return target;
        }
    }
}