using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class HeadwordInformationDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "hwi")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var headwordInfo = new HeadwordInformation();
            if (source.TryGetProperty("hw", out var hw))
            {
                headwordInfo.Text = hw.GetString();
            }

            if (source.TryGetProperty("prs", out var prs))
            {
                headwordInfo.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
            }

            target.Headword = headwordInfo;
        }
    }
}