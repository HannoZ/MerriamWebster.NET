using System;
using System.Diagnostics.CodeAnalysis;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET
{
    /// <summary>
    /// Provides configuration settings for the Merriam-Webster API client.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// The base address for the Merriam-Webster API.
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Uri)]
        public static readonly Uri ApiBaseAddress = new("https://www.dictionaryapi.com/api/v3/references/");

        /// <summary>
        /// The base address for media resources.
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Uri)]
        public static readonly Uri MediaBaseAddres = new("https://media.merriam-webster.com/audio/prons/");

        /// <summary>
        /// The placeholder URL for artwork HTML pages.
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Uri)]
        public static readonly string ArtworkHtmlPagePlaceholder = "https://www.merriam-webster.com/art/dict/{0}.htm";

        /// <summary>
        /// The placeholder URL for direct artwork links.
        /// </summary>
        [StringSyntax(StringSyntaxAttribute.Uri)]
        public static readonly string ArtworkDirectLinkPlaceholder = "https://www.merriam-webster.com/assets/mw/static/art/dict/{0}.gif";

        // API paths
        /// <summary>
        /// The path for the Collegiate Thesaurus API.
        /// </summary>
        public static readonly string CollegiateThesaurus = "thesaurus";

        /// <summary>
        /// The path for the Collegiate Dictionary API.
        /// </summary>
        public static readonly string CollegiateDictionary = "collegiate";

        /// <summary>
        /// The path for the Medical Dictionary API.
        /// </summary>
        public static readonly string MedicalDictionary = "medical";

        /// <summary>
        /// The path for the Learner's Dictionary API.
        /// </summary>
        public static readonly string LearnersDictionary = "learners";

        /// <summary>
        /// The path for the Elementary Dictionary API.
        /// </summary>
        public static readonly string ElementaryDictionary = "sd2";

        /// <summary>
        /// The path for the Intermediate Dictionary API.
        /// </summary>
        public static readonly string IntermediateDictionary = "sd3";

        /// <summary>
        /// The path for the Intermediate Thesaurus API.
        /// </summary>
        public static readonly string IntermediateThesaurus = "ithesaurus";

        /// <summary>
        /// The path for the School Dictionary API.
        /// </summary>
        public static readonly string SchoolDictionary = "sd4";

        /// <summary>
        /// The path for the Spanish-English Dictionary API.
        /// </summary>
        public static readonly string SpanishEnglishDictionary = "spanish";

        /// <summary>
        /// Gets or sets the <see cref="ParseOptions"/>.
        /// </summary>
        /// <remarks>Can be set at runtime to change the default behavior.</remarks>
        public static ParseOptions ParseOptions { get; set; } = ParseOptions.Default;

        /// <summary>
        /// Gets or sets the <see cref="Language"/>.
        /// </summary>
        /// <remarks>
        /// Only applies to audio links for entries in the Spanish-English dictionary with lang="es"
        /// </remarks>
        public static Language Language { get; set; } = Language.NotApplicable;
    }
}