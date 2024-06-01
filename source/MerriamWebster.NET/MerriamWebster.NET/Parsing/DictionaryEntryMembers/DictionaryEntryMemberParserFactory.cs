using System;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <summary>
    /// Factory for <see cref="IDictionaryEntryMemberParser"/> implementations.
    /// </summary>
    internal class DictionaryEntryMemberParserFactory 
    {
        public static IDictionaryEntryMemberParser? GetDictionaryEntryMemberParser(string api, string elementName)
        {
            return elementName switch
            {
                "meta" => new MetadataDictionaryEntryMemberParser(),
                "hwi" => new HeadwordInformationDictionaryEntryMemberParser(),
                "ahws" => new AlternateHeadwordInformationDictionaryEntryMemberParser(),
                "ins" => new InflectionDictionaryEntryMemberParser(),
                "vrs" => new VariantsDictionaryEntryMemberParser(),
                "cxs" => new CognateCrossReferenceDictionaryEntryMemberParser(),
                "def" => new DefinitionDictionaryEntryMemberParser(),
                "uros" => new UndefinedRunOnsDictionaryEntryMemberParser(),
                "dros" => new DefinedRunOnsDictionaryEntryMemberParser(),
                "art" => new ArtworkDictionaryEntryMemberParser(),
                "et" => new EtymologyDictionaryEntryMemberParser(),
                "dxnls" => new DirectionalCrossReferencesDictionaryEntryMemberParser(),
                "usages" => new UsagesDictionaryEntryMemberParser(),
                "syns" => new SynonymsDictionaryEntryMemberParser(),
                "quotes" => new QuotesDictionaryEntryMemberParser(),
                "table" => new TableDictionaryEntryMemberParser(),
                // medical dictionary only
                "bios" => new BiosDictionaryEntryMemberParser(),
                // spanish-english only 
                "suppl" => new ConjugationsDictionaryEntryMemberParser(),
                "xrs" => new CrossReferencesDictionaryEntryMemberParser(),
                _ => null
            };
        }
    }
}
