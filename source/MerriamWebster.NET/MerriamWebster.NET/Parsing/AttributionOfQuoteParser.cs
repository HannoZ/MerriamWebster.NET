using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse "aq" objects.
    /// </summary>
    public class AttributionOfQuoteParser
    {
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
                quote.Source = source;
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