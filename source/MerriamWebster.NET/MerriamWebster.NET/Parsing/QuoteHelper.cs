using MerriamWebster.NET.Parsing.Markup;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Quote = MerriamWebster.NET.Results.Quote;

namespace MerriamWebster.NET.Parsing
{
    internal class QuoteHelper
    {
        public static Quote Parse(Response.Quote source)
        {
            var quote = new Quote
            {
                Text = source.Text
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