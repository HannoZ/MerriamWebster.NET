using System;
using System.Text.Json;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class EtymologyDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "et")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            target.Etymology = EtymologyParser.Parse(source);
        }

    }
}