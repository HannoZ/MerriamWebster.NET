using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class UsagesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
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
                    ParagraphLabel = JsonParserHelper.GetStringValue(usageElement, "pl")
                };

                if (usageElement.TryGetProperty("pt", out var pt))
                {
                    usage.ParagraphTexts = new List<IDefiningText>();
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

            ((Entry)target).Usages = usages;
        }
    }

    public class DirectionalCrossReferencesDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
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
                references.Add(reference.GetString());
            }

            ((Entry)target).DirectionalCrossReferences = references;
        }
    }
}