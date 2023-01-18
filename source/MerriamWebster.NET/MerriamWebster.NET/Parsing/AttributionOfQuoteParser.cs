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
                Author = JsonParserHelper.GetStringValue(aq, "auth"),
                Source = JsonParserHelper.GetStringValue(aq, "source"),
                PublicationDate = JsonParserHelper.GetStringValue(aq, "aqdate")
            };

            if (aq.TryGetProperty("subsource", out var subsource))
            {
                quote.Subsource = new SubSource
                {
                    Source = JsonParserHelper.GetStringValue(subsource, "source"),
                    PublicationDate = JsonParserHelper.GetStringValue(subsource, "aqdate")
                };
            }

            return quote;
        }
    }
}