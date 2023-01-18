using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse "vis" objects. />
    /// </summary>
    public class VisParser
    {
        /// <summary>
        /// Parses the input into a <see cref="VerbalIllustration"/> instance.
        /// </summary>
        public static VerbalIllustration Parse(JsonElement visElement)
        {
            var vis = new VerbalIllustration
            {
                Sentence = JsonParserHelper.GetStringValue(visElement, "t"),
                // spanish-english only
                Translation = JsonParserHelper.GetStringValue(visElement, "tr")
            };

            if (visElement.TryGetProperty("aq", out var aq))
            {
                var quote = AttributionOfQuoteParser.Parse(aq);
                vis.AttributionOfQuote = quote;
            }

            return vis;
        }
    }
}