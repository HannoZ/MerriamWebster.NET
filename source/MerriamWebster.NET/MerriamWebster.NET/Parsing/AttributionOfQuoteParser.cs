using System.Text.Json;
using MerriamWebster.NET.Parsing.Markup;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse "aq" objects.
    /// </summary>
    public class AttributionOfQuoteParser
    {
        /// <summary>
        /// Parses an attribution of quote ("aq") object.
        /// </summary>
        /// <param name="aq">The aq element</param>
        /// <returns>A parsed <see cref="AttributionOfQuote"/> object.</returns>
        public static AttributionOfQuote Parse(JsonElement aq)
        {
            var quote = new AttributionOfQuote
            {
                Author = JsonParserHelper.GetStringValue(aq, "auth") ?? string.Empty,
                PublicationDate = JsonParserHelper.GetStringValue(aq, "aqdate")
            };

            var source = JsonParserHelper.GetStringValue(aq, "source");
            if (source != null)
            {
                // this works as long as the display is HTML but it's not the best solution
                var cleanSource = MarkupManipulator.RemoveMarkupFromString(source);
                quote.Source = $"<cite title=\"{cleanSource}\">{source}</cite>";
            }


            if (aq.TryGetProperty("subsource", out var subsource))
            {
                quote.Subsource = new SubSource
                {
                    PublicationDate = JsonParserHelper.GetStringValue(subsource, "aqdate")
                };

                var subSource = JsonParserHelper.GetStringValue(subsource, "source");
                if (subSource != null)
                {
                    quote.Subsource.Source = subSource;
                }
            }

            return quote;
        }
    }
}