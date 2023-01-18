using System;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    internal class DictionaryEntryMemberParserFactory
    {
        public static IDictionaryEntryMemberParser GetDictionaryEntryMemberParser(string api, string elementName)
        {
            switch (elementName)
            {
                case "meta":
                    if (api == Configuration.CollegiateThesaurus)
                    {
                        return new MetadataDictionaryEntryMemberParser();
                    }
                    else if (api == Configuration.SpanishEnglishDictionary)
                    {
                        return new SpanishEnglishMetadataDictionaryEntryMemberParser();
                    }
                    else
                    {
                        return new MetadataDictionaryEntryMemberParser();
                    }
                case "hwi":
                    return new HeadwordInformationDictionaryEntryMemberParser();
                case "ahws":
                    return new AlternateHeadwordInformationDictionaryEntryMemberParser();
                case "ins":
                    return new InflectionDictionaryEntryMemberParser();
                case "vrs":
                    return new VariantsDictionaryEntryMemberParser();
                case "cxs":
                    return new CognateCrossReferenceDictionaryEntryMemberParser();
                case "def":
                    return new DefinitionDictionaryEntryMemberParser();
                case "uros":
                    return new UndefinedRunOnsDictionaryEntryMemberParser();
                case "dros":
                    return new DefinedRunOnsDictionaryEntryMemberParser();
                case "art":
                    return new ArtworkDictionaryEntryMemberParser();
                case "et":
                    return new EtymologyDictionaryEntryMemberParser();
                case "dxnls":
                    return new DirectionalCrossReferencesDictionaryEntryMemberParser();
                case "usages":
                    return new UsagesDictionaryEntryMemberParser();

                // spanish-english only 
                case "suppl":
                    return new ConjugationsDictionaryEntryMemberParser();
                case "xrs":
                    return new CrossReferencesDictionaryEntryMemberParser();

                default: return null;
            }
        }
    }
}
