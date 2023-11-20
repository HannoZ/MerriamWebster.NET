using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Parser for <see cref="Inflection"/> ("ins") objects.
    /// </summary>
    public class InflectionsParser
    {
        /// <summary>
        /// Parses a <see cref="Inflection"/> ("ins") json element.
        /// </summary>
        /// <param name="source">The source element</param>
        /// <returns>The parsed inflection(s)</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="source"/> is not an array.</exception>
        public static IEnumerable<Inflection> Parse(JsonElement source)
        {
            if (source.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentException("The provided JSON must be an array of inflection objects");
            }

            foreach (var ins in source.EnumerateArray())
            {
                var inflection = new Inflection();
                if (ins.TryGetProperty("il", out var il))
                {
                    inflection.Label = il.GetString();
                }
                if (ins.TryGetProperty("if", out var ifElem))
                {
                    inflection.Value = ifElem.GetString();
                }
                if (ins.TryGetProperty("ifc", out var ifc))
                {
                    inflection.Cutback = ifc.GetString();
                }
                if (ins.TryGetProperty("spl", out var spl))
                {
                    inflection.SenseSpecificInflectionPluralLabel = spl.GetString();
                }
                if (ins.TryGetProperty("prs", out var prs))
                {
                    inflection.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                }

                // spanish-english only
                if (ins.TryGetProperty("aif", out var aif))
                {
                    var alt = new AlternateInflection();
                    if (aif.TryGetProperty("ifc", out var altIfc))
                    {
                        alt.Cutback =  altIfc.GetString();
                    }

                    if (aif.TryGetProperty("if", out var altIf))
                    {
                        alt.Inflection= altIf.GetString();
                    }

                    inflection.Alternate = alt;
                }

                yield return inflection;
            }
        }
    }
}