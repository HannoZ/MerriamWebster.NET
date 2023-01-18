using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse inflections.
    /// </summary>
    public class InflectionsParser
    {
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