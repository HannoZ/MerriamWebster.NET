using System;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    internal class InflectionDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "ins")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }
            var source = json.Value;

            target.Inflections = InflectionsParser.Parse(source).ToList();
        }
    }
}