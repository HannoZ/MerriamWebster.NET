using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class MetadataDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public virtual void Parse(JsonProperty json, Entry target) 
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "meta")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;

            var metadata = new Metadata
            {
                Id = JsonParserHelper.GetStringValue(source, "id") ?? string.Empty,
                Sort = JsonParserHelper.GetStringValue(source, "sort") ?? string.Empty,
                Source = JsonParserHelper.GetStringValue(source, "src") ?? string.Empty
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

            if (source.TryGetProperty("lang", out var lang)
                && Enum.TryParse<Language>(lang.GetString(), ignoreCase: true, out var language))
            {
               metadata.Language = language;
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