using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing
{
    public class SynonymsParser
    {
        private static readonly Regex SynonymsRegex = new Regex(@"{sx\|([\p{L}]*)\|\|}", RegexOptions.Compiled);

        /// <summary>
        /// Find any synonymns (recognizable by {sx} markup) in the provided input string.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Returns any synonyms that are found in the input string.</returns>
        public static IEnumerable<string> ExtractSynonyms(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

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
