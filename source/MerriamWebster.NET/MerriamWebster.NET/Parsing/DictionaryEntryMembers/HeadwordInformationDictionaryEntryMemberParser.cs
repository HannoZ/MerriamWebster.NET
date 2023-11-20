using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses headword information ("hwi") json object.
    /// </summary>
    public class HeadwordInformationDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
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