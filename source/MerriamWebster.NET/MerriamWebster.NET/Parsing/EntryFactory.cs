using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET.Parsing
{
    internal class EntryFactory
    {
        public static EntryBase CreateEntry(string api)
        {
            if (api == Configuration.SpanishEnglishDictionary)
            {
                return new SpanishEnglishEntry();
            }
            else if (api == Configuration.MedicalDictionary)
            {
                // todo medical entry
                return new Entry();
            }

            return new Entry();
        }
    }
}