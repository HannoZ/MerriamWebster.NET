using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class QuotesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
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
                    Text = JsonParserHelper.GetStringValue(q, "t")
                };

                if (q.TryGetProperty("aq", out var aq))
                {
                    quote.AttributionOfQuote = AttributionOfQuoteParser.Parse(aq);
                }

                quotes.Add(quote);
            }

            ((Entry)target).Quotes = quotes;
        }
    }
}