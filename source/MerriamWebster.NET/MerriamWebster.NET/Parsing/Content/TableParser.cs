using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class TableParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source.Table != null)
            {
                target.Table = new Dto.Table
                {
                    Displayname = source.Table.Displayname,
                    TableId = source.Table.Tableid
                };
            }

            return target;
        }
    }
}