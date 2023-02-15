using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class QuotesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "quotes")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var quotes = new List<Quote>();

            foreach (var q in source.EnumerateArray())
            {
                var quote = new Quote
                {
                    Text = JsonParserHelper.GetStringValue(q, "t") ?? string.Empty,
                };

                if (q.TryGetProperty("aq", out var aq))
                {
                    quote.AttributionOfQuote = AttributionOfQuoteParser.Parse(aq);
                }

                quotes.Add(quote);
            }

            target.Quotes = quotes;
        }
    }
}