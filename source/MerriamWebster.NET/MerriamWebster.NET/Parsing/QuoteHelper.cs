using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing.Markup;
using MerriamWebster.NET.Response;
using Quote = MerriamWebster.NET.Dto.Quote;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse the <see cref="Response.Quote"/>
    /// </summary>
    public class QuoteHelper
    {
        /// <summary>
        /// Converts <see cref="Response.Quote"/> to <see cref="Quote"/>
        /// </summary>
        /// <param name="source">The source quote</param>
        /// <param name="options">The parse options.</param>
        /// <returns>A new <see cref="Quote"/> object (empty if source was null).</returns>
        public static Quote Parse(Response.Quote source, ParseOptions options)
        {
            var quote = new Quote
            {
                Text = new FormattedText(source.Text, options)
            };

            var aq = source.Aq;
            if (aq != null)
            {
                quote.AttributionOfQuote = new AttributionOfQuote
                {
                    Author = aq.Author,
                    PublicationDate = aq.PublicationDate,
                    Source = MarkupManipulator.RemoveMarkupFromString(aq.Source)
                };

                if (aq.Subsource != null)
                {
                    aq.Subsource = new Subsource
                    {
                        PublicationDate = aq.Subsource.PublicationDate,
                        Source = MarkupManipulator.RemoveMarkupFromString(aq.Subsource.Source)
                    };
                }
            }

            return quote;
        }
    }
}