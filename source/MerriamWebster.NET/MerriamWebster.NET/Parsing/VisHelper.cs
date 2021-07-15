using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse "vis" entries found on <see cref="Response.DefiningText"/>
    /// </summary>
    internal class VisHelper
    {
        public static VerbalIllustration Parse(Response.DefiningText source)
        {
            if (source == null)
            {
                return null;
            }

            var text = source.Text;
            var vis = new VerbalIllustration
            {
                Sentence = text,
                Translation = source.Translation
            };

            var aq = source.Quote;
            if (aq != null)
            {
                vis.AttributionOfQuote = new AttributionOfQuote
                {
                    Author = aq.Author,
                    PublicationDate = aq.PublicationDate,
                    Source = aq.Source
                };

                if (aq.Subsource != null)
                {
                    vis.AttributionOfQuote.Subsource = new SubSource
                    {
                        PublicationDate = aq.Subsource.PublicationDate,
                        Source = aq.Subsource.Source
                    };
                }
            }

            return vis;
        }
    }
}