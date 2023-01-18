using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class DefinedRunOnsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
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
                var runon = new DefinedRunOn
                {
                    Phrase = JsonParserHelper.GetStringValue(dro, "drp"),
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