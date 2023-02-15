using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains logic to extract synonyms that may appear as links in senses.
    /// </summary>
    public partial class SynonymsParser
    {

#if NET7_0_OR_GREATER

        private static readonly Regex SynonymsRegex = SynPattern();

        [GeneratedRegex("{sx\\|([\\p{L}]*\\s?[\\p{L}]*?)\\|\\|}")]
        private static partial Regex SynPattern();
#else
        private static readonly Regex SynonymsRegex = new Regex("{sx\\|([\\p{L}]*\\s?[\\p{L}]*?)\\|\\|}", RegexOptions.Compiled);
#endif

        /// <summary>
        /// Find any synonymns (recognizable by {sx} markup) in the provided input string.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Returns any synonyms that are found in the input string.</returns>
        public static IEnumerable<string> ExtractSynonyms(string input)
        {
            ArgumentNullException.ThrowIfNull(input);
            
            var results = new List<string>();
            var matches = SynonymsRegex.Matches(input);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    results.Add(match.Groups[1].Value);
                }
            }

            return results;
        }

    }
}
