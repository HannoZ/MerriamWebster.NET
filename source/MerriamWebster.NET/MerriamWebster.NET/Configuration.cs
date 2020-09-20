using System;

namespace MerriamWebster.NET
{
    public static class Configuration
    {
        public static readonly Uri ApiBaseAddress = new Uri("https://www.dictionaryapi.com/api/v3/references/");
        public static readonly Uri MediaBaseAddres = new Uri("https://media.merriam-webster.com/audio/prons/");

        // api paths
        public static readonly string CollegiateThesaurus = "thesaurus";
        public static readonly string CollegiateDictionary = "collegiate";
        public static readonly string MedicalDictionary = "medical";
        public static readonly string LearnersDictionary = "learners";
        public static readonly string ElementaryDictionary = "sd2";
        public static readonly string IntermediateDictionary = "sd3";
        public static readonly string IntermediateThesaurus = "ithesaurus";
        public static readonly string SchoolDictionary = "sd4"; 
        public static readonly string SpanishEnglishDictionary = "spanish";
    }
}
