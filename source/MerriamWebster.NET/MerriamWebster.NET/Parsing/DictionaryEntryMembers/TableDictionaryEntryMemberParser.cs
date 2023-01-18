using System;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class TableDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "table")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var table = new Table()
            {
                Displayname = JsonParserHelper.GetStringValue(source, "displayname"),
                TableId = JsonParserHelper.GetStringValue(source, "tableid")
            };
            
            ((Entry)target).Table = table;
        }
    }
}