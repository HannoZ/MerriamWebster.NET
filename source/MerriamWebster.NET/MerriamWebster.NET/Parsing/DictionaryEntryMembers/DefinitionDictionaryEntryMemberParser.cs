﻿using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the definition ("def") json object.
    /// </summary>
    public class DefinitionDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "def")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var definitions = source.EnumerateArray();
            foreach (var def in definitions)
            {
                var definition = DefinitionParser.Parse(def);
                target.Definitions.Add(definition);
            }
        }
    }
}