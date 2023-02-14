using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <inheritdoc />
    public class SynonymsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "syns")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var synonyms = new List<Synonym>();

            foreach (var synonymElement in source.EnumerateArray())
            {
                var synonym = new Synonym()
                {
                    ParagraphLabel = JsonParserHelper.GetStringValue(synonymElement, "pl") ?? string.Empty
                };

                if (synonymElement.TryGetProperty("pt", out var pt))
                {
                    synonym.ParagraphTexts = new List<IDefiningText>();
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
                                synonym.ParagraphTexts.Add(parser.Parse(arrElement));
                            }
                        }
                        else
                        {
                            synonym.ParagraphTexts.Add(parser.Parse(items[1]));
                        }
                    }
                }

                if (synonymElement.TryGetProperty("sarefs", out var refs))
                {
                    synonym.SeeInAdditionReference = new List<string>();
                    foreach (var reference in refs.EnumerateArray())
                    {
                        var refString = reference.GetString();
                        if (refString != null)
                        {
                            synonym.SeeInAdditionReference.Add(refString);
                        }
                    }
                }

                synonyms.Add(synonym);
            }

            target.Synonyms = synonyms;
        }
    }
}