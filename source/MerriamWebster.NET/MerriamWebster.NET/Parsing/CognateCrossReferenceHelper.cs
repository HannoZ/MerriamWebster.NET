using System.Collections.Generic;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse <see cref="Response.CognateCrossReference"/>
    /// </summary>
    public class CognateCrossReferenceHelper
    {
        /// <summary>
        /// Converts <see cref="Response.CognateCrossReference"/> to <see cref="CognateCrossReference"/>
        /// </summary>
        /// <param name="sources">The source cognate references</param>
        /// <returns>A new <see cref="CognateCrossReference"/> object for each source reference</returns>
        public static IEnumerable<CognateCrossReference> Parse(Response.CognateCrossReference[] sources)
        {
            foreach (var source in sources)
            {
                var target = new CognateCrossReference
                {
                    Label = source.Label
                };

                foreach (var crossReferenceTarget in source.CrossReferenceTargets)
                {
                    target.CrossReferenceTargets.Add(new Dto.CrossReferenceTarget
                    {
                        Target = crossReferenceTarget.Target,
                        Label = crossReferenceTarget.Label,
                        TargetId = crossReferenceTarget.TargetId,
                        SenseNumber = crossReferenceTarget.SenseNumber
                    });
                }

                yield return target;
            }
        }
    }
}