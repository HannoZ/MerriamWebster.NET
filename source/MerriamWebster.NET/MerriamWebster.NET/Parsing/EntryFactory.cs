using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.Medical;
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
            if (api == Configuration.MedicalDictionary)
            {
                return new MedicalEntry();
            }

            return new Entry();
        }
    }
}