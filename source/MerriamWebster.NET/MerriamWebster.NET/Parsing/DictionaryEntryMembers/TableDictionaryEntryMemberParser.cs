using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class TableDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
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
            
            target.Table = table;
        }
    }
}