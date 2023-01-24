using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class MetadataDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public virtual void Parse(JsonProperty json, EntryBase target) 
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "meta")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var metadata = new Metadata
            {
                Id = JsonParserHelper.GetStringValue(source, "id"),
                Sort = JsonParserHelper.GetStringValue(source, "sort"),
                Source = JsonParserHelper.GetStringValue(source, "src")
            };

            if (source.TryGetProperty("uuid", out var uuidElem)
                && uuidElem.TryGetGuid(out var uuid))
            {
                metadata.UniqueIdentifier = uuid;
            }

            if (source.TryGetProperty("offensive", out var offensive))
            {
                metadata.Offensive = offensive.GetBoolean();
            }

            if (source.TryGetProperty("section", out var sectionElem))
            {
                var section = sectionElem.GetString();
                if (section != null)
                {
                    metadata.Section = ParseSection(section);
                }
            }

            var stems = JsonParserHelper.GetStringValues(source, "stems");
            if (stems != null)
            {
                metadata.Stems = new List<string>();
                foreach (var stem in stems)
                {
                    metadata.Stems.Add(stem);
                }
            }

            target.Metadata = metadata;
        }

        private static string ParseSection(string section)
        {
            return section.ToLower() switch
            {
                "alpha" => "Alphabetical",
                "biog" => "Biographical",
                "geog" => "Geographical",
                "idioms" => "Idioms",
                "fw&p" => "Foreign words & phrases",
                _ => section
            };
        }



    }
}