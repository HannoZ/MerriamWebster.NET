using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the defined run-ons ("dros") json property.
    /// </summary>
    public class DefinedRunOnsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "dros")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            var runons = new List<DefinedRunOn>();
            foreach (var dro in source.EnumerateArray())
            {
                var phrase = JsonParserHelper.GetStringValue(dro, "drp");
                if (string.IsNullOrEmpty(phrase))
                {
                    continue;
                }
                var runon = new DefinedRunOn
                {
                    Phrase = phrase,
                    GeneralLabels = LabelsParser.ParseMultiple<GeneralLabel>(dro, "lbs"),
                    ParenthesizedSubjectStatusLabel = LabelsParser.ParseSingle<ParenthesizedSubjectStatusLabel>(dro, "psl"),
                    SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(dro, "sls"),
                    // spanish-english only
                    FunctionalLabel = LabelsParser.ParseSingle<FunctionalLabel>(dro, "fl")
                };

                if (dro.TryGetProperty("def", out var defs))
                {
                    runon.Definitions = new List<Definition>();
                    foreach (var def in defs.EnumerateArray())
                    {
                        runon.Definitions.Add(DefinitionParser.Parse(def));
                    }
                }

                if (dro.TryGetProperty("et", out var et))
                {
                    runon.Etymology = EtymologyParser.Parse(et);
                }

                if (dro.TryGetProperty("prs", out var prs))
                {
                    runon.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                }

                if (dro.TryGetProperty("vrs", out var vrs))
                {
                    runon.Variants = new List<Variant>(VariantParser.Parse(vrs));
                }

                runons.Add(runon);
            }

            target.DefinedRunOns = runons;
        }
    }
}