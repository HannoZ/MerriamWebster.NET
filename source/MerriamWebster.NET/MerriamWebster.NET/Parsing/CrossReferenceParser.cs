using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Spanish-English only
    /// </summary>
    public class CrossReferenceParser
    {
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
                        crossReference.Text = xrt.ToString();
                    }

                    if (xrs.TryGetProperty("xref", out var xref))
                    {
                        crossReference.Target = xref.GetString();
                    }

                    yield return crossReference;
                }
            }
        }
    }
}