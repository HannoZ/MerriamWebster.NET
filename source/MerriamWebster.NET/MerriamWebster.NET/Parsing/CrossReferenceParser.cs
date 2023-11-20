using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// <i>Spanish-English only.</i> Parses the cross-reference ("xrs") object.
    /// </summary>
    public class CrossReferenceParser
    {
        /// <summary>
        /// Parses a cross-reference object.
        /// </summary>
        /// <param name="source">The object to parse</param>
        /// <returns>The parsed cross reference(s)</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="source"/> was not an array</exception>
        public static IEnumerable<CrossReference> Parse(JsonElement source)
        {
            if (source.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentException("The provided JSON must be an array of cross-reference objects");
            }

            foreach (var outerXrs in source.EnumerateArray())
            {
                foreach (var xrs in outerXrs.EnumerateArray())
                {
                    var crossReference = new CrossReference();
                    if (xrs.TryGetProperty("xrt", out var xrt))
                    {
                        crossReference.Text = xrt.GetString() ?? string.Empty;
                    }

                    if (xrs.TryGetProperty("xref", out var xref))
                    {
                        crossReference.Target = xref.GetString() ?? string.Empty;
                    }

                    yield return crossReference;
                }
            }
        }
    }
}