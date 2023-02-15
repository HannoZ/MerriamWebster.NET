using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// An IDictionaryEntryMemberParser is able to parse one top-level dictionary entry member and nothing else.
    /// </summary>
    public interface IDictionaryEntryMemberParser
    {
        /// <summary>
        /// Parse the incoming json property and add the result to the corresponding target entry property.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="target"></param>
        void Parse(JsonProperty json, Entry target);
    }
}