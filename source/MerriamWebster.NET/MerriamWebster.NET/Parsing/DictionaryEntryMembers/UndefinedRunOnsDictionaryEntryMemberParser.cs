using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the undefined run-ons ("uros") json object.
    /// </summary>
    public class UndefinedRunOnsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
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
                var word = JsonParserHelper.GetStringValue(uro, "ure");
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }

                var runon = new UndefinedRunOn
                {
                    EntryWord = word,
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
                    runon.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                }

                if (uro.TryGetProperty("vrs", out var vrs))
                {
                    runon.Variants = new List<Variant>(VariantParser.Parse(vrs));
                }

                // spanish-english only
                if (uro.TryGetProperty("aure", out var aure))
                {
                    var text = JsonParserHelper.GetStringValue(aure, "ure");
                    if (text != null)
                    {
                        runon.AlternateEntry = new AlternateUndefinedEntryWord()
                        {
                            Text = text,
                            TextCutback = JsonParserHelper.GetStringValue(aure, "urec")
                        };
                    }
                }

                runons.Add(runon);
            }

            target.UndefinedRunOns = runons;
        }
    }
}



