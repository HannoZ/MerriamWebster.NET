using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for more-at-target links (mat).
    /// </summary>
    public class MoreAtTargetManipulator : MarkupManipulator, IMarkupManipulator
    {
        private static readonly Regex Pattern = new Regex(@"{mat\|([^}]*)\|[^}]*}", RegexOptions.Compiled);

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