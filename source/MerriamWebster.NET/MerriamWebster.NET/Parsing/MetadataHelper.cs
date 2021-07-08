using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;
using Metadata = MerriamWebster.NET.Dto.Metadata;
using Section = MerriamWebster.NET.Dto.Section;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse the <see cref="Response.Metadata"/>
    /// </summary>
    public class MetadataHelper
    {
        /// <summary>
        /// Converts <see cref="Response.Metadata"/> to <see cref="Metadata"/>
        /// </summary>
        /// <param name="entry">The source dictionary entry that holds the metadata.</param>
        /// <returns>A new <see cref="Metadata"/> object (empty if source was null).</returns>
        public static Metadata Parse(DictionaryEntry entry)
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
                Section = Section.Unknown, // TODO
                Language = (Language)meta.Lang
            };
        }
    }
}