using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish
{
    /// <summary>
    /// <i>Spanish-English only</i>. Parses a cross-references ("xrs") json object.
    /// </summary>
    public class CrossReferencesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "xrs")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            target.CrossReferences = new List<CrossReference>(CrossReferenceParser.Parse(source));
        }
    }
}