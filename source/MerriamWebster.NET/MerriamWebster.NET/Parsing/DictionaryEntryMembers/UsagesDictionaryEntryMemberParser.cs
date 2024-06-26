﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Parses the <see cref="Usage"/>s of a dictionary entry.
    /// </summary>
    public class UsagesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "usages")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var usages = new List<Usage>();

            foreach (var usageElement in source.EnumerateArray())
            {
                var usage = new Usage
                {
                    ParagraphLabel = JsonParserHelper.GetStringValue(usageElement, "pl") ?? string.Empty    
                };

                if (usageElement.TryGetProperty("pt", out var pt))
                {
                    usage.ParagraphTexts = [];
                    foreach (var ptElement in pt.EnumerateArray())
                    {
                        var items = ptElement.EnumerateArray().ToList();
                        var type = items[0].GetString();

                        var parser = DefiningTextParserFactory.Create(type);
                        if (parser == null)
                        {
                            continue;
                        }

                        if (items[1].ValueKind == JsonValueKind.Array)
                        {
                            foreach (var arrElement in items[1].EnumerateArray())
                            {
                                usage.ParagraphTexts.Add(parser.Parse(arrElement));
                            }
                        }
                        else
                        {
                            usage.ParagraphTexts.Add(parser.Parse(items[1]));
                        }
                    }
                }

                usages.Add(usage);
            }

            target.Usages = usages;
        }
    }
}