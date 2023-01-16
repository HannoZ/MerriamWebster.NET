using System.Text.Json;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.Content
{
    public interface IDictionaryEntryMemberParser
    {
        void Parse(JsonProperty json, EntryBase target);
    }
}