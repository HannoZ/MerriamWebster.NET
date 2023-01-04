using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Table = MerriamWebster.NET.Results.Table;

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
                target.Table = new Table
                {
                    Displayname = source.Table.Displayname,
                    TableId = source.Table.Tableid
                };
            }

            return target;
        }
    }
}