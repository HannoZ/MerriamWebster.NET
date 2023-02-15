using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class DirectionalCrossReferencesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "dxnls")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            var references = new List<FormattedText>();

            foreach (var reference in source.EnumerateArray())
            {
                var refString = reference.GetString();
                if (!string.IsNullOrEmpty(refString))
                {
                    references.Add(refString);
                }
            }

            target.DirectionalCrossReferences = references;
        }
    }
}