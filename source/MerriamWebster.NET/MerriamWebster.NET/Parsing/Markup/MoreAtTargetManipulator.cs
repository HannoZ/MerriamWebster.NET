using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for more-at-target links (mat).
    /// </summary>
    public partial class MoreAtTargetManipulator : MarkupManipulator, IMarkupManipulator
    {

#if NET7_0_OR_GREATER

        private static readonly Regex Pattern = ParsePattern();

        [GeneratedRegex(@"{mat\|([^}]*)\|[^}]*}")]
        private static partial Regex ParsePattern();
#else
        private static readonly Regex Pattern = new Regex(@"{mat\|([^}]*)\|[^}]*}", RegexOptions.Compiled);
#endif

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            input = input.Replace("{ma}", "— more at ")
                .Replace("{/ma}", "");

            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            input = input.Replace("{ma}", "— more at ")
                .Replace("{/ma}", "");

            return RegexReplace(input, Pattern, "span", "mw-mat");
        }
    }
}