using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish
{
    public class CrossReferencesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "xrs")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            ((SpanishEnglishEntry)target).CrossReferences = new List<CrossReference>(CrossReferenceParser.Parse(source));
        }
    }
}