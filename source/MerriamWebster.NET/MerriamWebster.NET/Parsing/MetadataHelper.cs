using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;
using Metadata = MerriamWebster.NET.Dto.Metadata;
using Section = MerriamWebster.NET.Dto.Section;

namespace MerriamWebster.NET.Parsing
{
    internal static class MetadataHelper
    {
        /// <summary>
        /// Converts <see cref="Response.Metadata"/> to <see cref="Metadata"/>
        /// </summary>
        /// <param name="entry">The source dictionary entry that holds the metadata.</param>
        /// <returns>A new <see cref="Metadata"/> object (empty if source was null).</returns>
        public static Metadata ParseMetadata(this DictionaryEntry entry)
        {
            var meta = entry?.Metadata;
            if (meta == null)
            {
                return new Metadata();
            }

            return new Metadata
            {
                Id = meta.Id,
                Offensive = meta.Offensive,
                Sort = meta.Sort,
                Stems = meta.Stems,
                Section = ParseSection(meta.Section),
                Language = (Language)meta.Lang
            };
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