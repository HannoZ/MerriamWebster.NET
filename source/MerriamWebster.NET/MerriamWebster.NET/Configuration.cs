using System;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class Configuration
    {
        public static readonly Uri ApiBaseAddress = new Uri("https://www.dictionaryapi.com/api/v3/references/");
        public static readonly Uri MediaBaseAddres = new Uri("https://media.merriam-webster.com/audio/prons/");

        public static readonly string ArtworkHtmlPagePlaceholder = "https://www.merriam-webster.com/art/dict/{0}.htm";
        public static readonly string ArtworkDirectLinkPlaceholder = "https://www.merriam-webster.com/assets/mw/static/art/dict/{0}.gif";

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

        /// <summary>
        /// Gets or sets the <see cref="ParseOptions"/>.
        /// </summary>
        /// <remarks>Can be set at runtime to change the default behavior.</remarks>
        public static ParseOptions ParseOptions {get; set; } = ParseOptions.Default;
        
        /// <summary>
        /// Gets or sets the <see cref="Language"/>.
        /// </summary>
        /// <remarks>
        /// Only applies to audio links for entries in the Spanish-English dictionary with lang="es"
        /// </remarks>
        public static Language Language { get; set; } = Language.NotApplicable;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
