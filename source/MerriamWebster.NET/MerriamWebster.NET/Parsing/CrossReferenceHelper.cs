using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET.Parsing
{
    internal class CrossReferenceHelper
    {
        /// <summary>
        /// Converts <see cref="Response.CrossReference"/> to <see cref="CrossReference"/>
        /// </summary>
        public static IEnumerable<CrossReference> Parse(Response.CrossReference[][] sources)
        {
            foreach (var crossReference in sources.SelectMany(cr => cr))
            {
                yield return new CrossReference
                {
                    Target = crossReference.Target,
                    Text = crossReference.Text
                };
            }
        }
    }
}