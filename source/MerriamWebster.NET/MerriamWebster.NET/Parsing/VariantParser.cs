using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse variants.
    /// </summary>
    public class VariantParser
    {
        /// <summary>
        /// Parses variants
        /// </summary>
        /// <param name="source">The source element that is - OR - should contain the "vrs" property.</param>
        public static IEnumerable<Variant> Parse(JsonElement source)
        {
            if (source.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentException("The provided JSON must be an array of variant objects");
            }
            
            foreach (var variantElement in source.EnumerateArray())
            {
                var variant = new Variant();
                if (variantElement.TryGetProperty("va", out var va))
                {
                    variant.Text = va.GetString();
                }

                if (variantElement.TryGetProperty("vl", out var vl))
                {
                    variant.Label = vl.GetString();
                }

                if (variantElement.TryGetProperty("spl", out var spl))
                {
                    variant.SenseSpecificInflectionPluralLabel = spl.GetString();
                }

                if (variantElement.TryGetProperty("prs", out var prs))
                {
                    variant.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                }

                // spanish-english only
                if (variantElement.TryGetProperty("vac", out var vac))
                {
                    variant.Cutback = vac.GetString();
                }

                yield return variant;
            }

        }
    }
}