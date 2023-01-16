using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.Content
{
    public class AlternateHeadwordInformationDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "ahws")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            target.AlternateHeadwords = new List<AlternateHeadwordInformation>();

            foreach (var ahw in source.EnumerateArray())
            {
                var altHw = new AlternateHeadwordInformation
                {
                    Text = JsonParserHelper.GetStringValue(ahw, "hw"),
                    HeadwordCutback = JsonParserHelper.GetStringValue(ahw, "hwc"),
                    ParenthesizedSubjectStatusLabel = LabelsParser.ParseSingle<ParenthesizedSubjectStatusLabel>(ahw, "psl")
                };

                if (ahw.TryGetProperty("prs", out var prs))
                {
                    altHw.Pronunciations = new List<Pronunciation>(PronuncationParser.Parse(prs));
                }

                target.AlternateHeadwords.Add(altHw);
            }

        }
    }
}