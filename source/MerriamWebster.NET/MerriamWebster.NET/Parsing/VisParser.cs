using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse "vis" entries that occur inside defining texts. />
    /// </summary>
    public class VisParser
    {
        /// <summary>
        /// Parses the input into a <see cref="VerbalIllustration"/> instance.
        /// </summary>
        public static VerbalIllustration Parse(JsonElement visElement)
        {
            var vis = new VerbalIllustration();
            if (visElement.TryGetProperty("t", out var t))
            {
                vis.Sentence = t.GetString();
            }
            if (visElement.TryGetProperty("tr", out var tr))
            {
                vis.Translation = tr.GetString();
            }

            if (visElement.TryGetProperty("aq", out var aq))
            {
                var quote = new AttributionOfQuote();
                if (aq.TryGetProperty("auth", out var auth))
                {
                    quote.Author = auth.GetString();
                }

                if (aq.TryGetProperty("source", out var source))
                {
                    quote.Source = source.GetString(); 
                }

                if (aq.TryGetProperty("aqdate", out var date))
                {
                    quote.PublicationDate = date.GetString();
                }

                if (aq.TryGetProperty("subsource", out var subsource))
                {
                    quote.Subsource = new SubSource();
                    if (subsource.TryGetProperty("source", out var ssource))
                    {
                        quote.Subsource.Source = ssource.GetString();
                    }

                    if (subsource.TryGetProperty("aqdate", out var sdate))
                    {
                        quote.Subsource.PublicationDate = sdate.GetString();
                    }
                }

                vis.AttributionOfQuote = quote;
            }

            return vis;
        }
    }
}