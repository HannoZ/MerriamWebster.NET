using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class UndefinedRunOnsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "uros")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            var runons = new List<UndefinedRunOn>();
            foreach (var uro in source.EnumerateArray())
            {
                var runon = new UndefinedRunOn
                {
                    EntryWord = JsonParserHelper.GetStringValue(uro, "ure"),
                    FunctionalLabel = LabelsParser.ParseSingle<FunctionalLabel>(uro, "fl"),
                    ParenthesizedSubjectStatusLabel = LabelsParser.ParseSingle<ParenthesizedSubjectStatusLabel>(uro, "psl"),
                    GeneralLabels = LabelsParser.ParseMultiple<GeneralLabel>(uro, "lbs"),
                    SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(uro, "sls")
                };

                if (uro.TryGetProperty("utxt", out var utxt))
                {
                    runon.RunOnTexts = new List<IDefiningText>();

                    foreach (var runTextSection in utxt.EnumerateArray())
                    {
                        var items = runTextSection.EnumerateArray().ToList();
                        if (items.Count != 2)
                        {
                            continue;
                        }

                        var type = items[0].GetString();
                        if (type == DefiningTextTypes.VerbalIllustration)
                        {
                            foreach (var visElement in items[1].EnumerateArray())
                            {
                                runon.RunOnTexts.Add(VisParser.Parse(visElement));
                            }
                        }
                        else if (type == "uns")
                        {
                            var parser = new UsageNoteDefiningTextParser();
                            runon.RunOnTexts.Add(parser.Parse(items[1]));
                        }
                    }
                }

                if (uro.TryGetProperty("ins", out var ins))
                {
                    runon.Inflections = new List<Inflection>(InflectionsParser.Parse(ins));
                }

                if (uro.TryGetProperty("prs", out var prs))
                {
                    runon.Pronunciations = new List<Pronunciation>(PronuncationParser.Parse(prs));
                }

                if (uro.TryGetProperty("vrs", out var vrs))
                {
                    runon.Variants = new List<Variant>(VariantParser.Parse(vrs));
                }

                // spanish-english only
                if (uro.TryGetProperty("aure", out var aure))
                {
                    runon.AlternateEntry = new AlternateUndefinedEntryWord()
                    {
                        Text = JsonParserHelper.GetStringValue(aure, "ure"),
                        TextCutback = JsonParserHelper.GetStringValue(aure, "urec")
                    };
                }

                runons.Add(runon);
            }

            target.UndefinedRunOns = runons;
        }
    }
}



