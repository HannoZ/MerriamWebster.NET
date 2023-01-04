using System;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Metadata = MerriamWebster.NET.Results.Metadata;
using Section = MerriamWebster.NET.Results.Section;
using Target = MerriamWebster.NET.Results.Target;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class MetadataParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            
            var sourceMeta = source?.Metadata;
            if (sourceMeta == null)
            {
                target.Metadata = new Metadata();
                return target;
            }

            var metadata = new Metadata
            {
                Id = sourceMeta.Id,
                Offensive = sourceMeta.Offensive,
                Sort = sourceMeta.Sort,
                Stems = sourceMeta.Stems,
                Section = ParseSection(sourceMeta.Section),
                Language = (Language)sourceMeta.Lang
            };

            // syns/ants are defined as two-dimensional arrays, 
            // but it looks like they only contain one list of items
            if (sourceMeta.Synonyms.HasValue())
            {
                metadata.Synonyms = sourceMeta.Synonyms.SelectMany(s => s).ToList();
            }
            if (sourceMeta.Antonyms.HasValue())
            {
                metadata.Antonyms = sourceMeta.Antonyms.SelectMany(s => s).ToList();
            }

            if (sourceMeta.Target != null)
            {
                metadata.Target = new Target
                {
                    Identifier = sourceMeta.Target.Identifier,
                    Source = sourceMeta.Target.Source
                };
            }

            target.Metadata = metadata;
            return target;
        }

        private static Section ParseSection(Response.Section section)
        {
            switch (section)
            {
                case Response.Section.Alpha:
                    return Section.Alphabetical;
                case Response.Section.Biog:
                    return Section.Biographical;
                case Response.Section.Geog:
                    return Section.Geographical;
                case Response.Section.Idioms:
                    return Section.Idioms;
                default:
                    return Section.Unknown;
            }
        }
    }
}
