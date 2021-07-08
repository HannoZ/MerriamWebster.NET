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
        /// 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
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