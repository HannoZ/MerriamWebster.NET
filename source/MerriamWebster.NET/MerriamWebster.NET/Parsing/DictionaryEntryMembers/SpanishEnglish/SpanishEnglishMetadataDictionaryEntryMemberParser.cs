using System;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish
{
    public class SpanishEnglishMetadataDictionaryEntryMemberParser : MetadataDictionaryEntryMemberParser
    {
        public override void Parse(JsonProperty json, EntryBase target)
        {
            base.Parse(json, target);

            var spanishEnglishEntry = (SpanishEnglishEntry)target;

            var source = json.Value;
            if (source.TryGetProperty("lang", out var lang)
                && Enum.TryParse<Language>(lang.GetString(), ignoreCase: true, out var language))
            {
                spanishEnglishEntry.Metadata.Language = language;
            }

        }
    }
}
