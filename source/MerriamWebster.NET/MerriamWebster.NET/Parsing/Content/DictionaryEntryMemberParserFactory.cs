using System;
using MerriamWebster.NET.Parsing.Content.SpanishEnglish;

namespace MerriamWebster.NET.Parsing.Content
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
                        return new SpanishEnglishJsonMetadataParser();
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
                    return new CognateCrossReferenceJsonParser();
                case "def":
                    return new DefinitionDictionaryEntryMemberParser();
                case "uros":
                    return new UndefinedRunOnsDictionaryEntryMemberParser();
                case "dros":
                    return new DefinedRunOnsDictionaryEntryMemberParser();
                case "art":
                    return new ArtworkDictionaryEntryMemberParser();

                // spanish-english only 
                case "suppl":
                    return new ConjugationsParser();
                case "xrs":
                    return new CrossReferencesDictionaryEntryMemberParser();

                default: return null;
            }
        }
    }
}
