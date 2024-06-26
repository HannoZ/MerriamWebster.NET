﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the alternate headword information ("ahws") object.
    /// </summary>
    public class AlternateHeadwordInformationDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentException"><paramref name="json"/>.Name is not "ahws"</exception>
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "ahws")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            target.AlternateHeadwords = [];

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
                    altHw.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                }

                target.AlternateHeadwords.Add(altHw);
            }

        }
    }
}