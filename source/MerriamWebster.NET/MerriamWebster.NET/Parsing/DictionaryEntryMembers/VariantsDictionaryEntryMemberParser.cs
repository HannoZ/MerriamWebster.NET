using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the <see cref="Variant"/>s of a dictionary entry.
    /// </summary>
    public class VariantsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "vrs")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            target.Variants = new List<Variant>(VariantParser.Parse(source));
        }
    }
}