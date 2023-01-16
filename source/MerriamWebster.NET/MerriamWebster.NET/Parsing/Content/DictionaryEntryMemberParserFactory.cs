﻿using System;
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
                        return new JsonMetadataParser();
                    }
                    else if (api == Configuration.SpanishEnglishDictionary)
                    {
                        return new SpanishEnglishJsonMetadataParser();
                    }
                    else
                    {
                        return new JsonMetadataParser();
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
                case "uros":
                    return new UndefinedRunOnsDictionaryEntryMemberParser();

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
