using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse <see cref="Response.CrossReference"/>
    /// </summary>
    public class CrossReferenceHelper
    {
        /// <summary>
        /// Converts <see cref="Response.CrossReference"/> to <see cref="CrossReference"/>
        /// </summary>
        /// <param name="sources">The source cross-references</param>
        /// <returns>A new <see cref="CrossReference"/> object for each source cross-reference</returns>
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