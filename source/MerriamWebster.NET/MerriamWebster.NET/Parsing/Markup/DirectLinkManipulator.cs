using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for direct links (d_link).
    /// </summary>
    public class DirectLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
        private static readonly Regex Pattern = new Regex(@"{d_link\|([^}]*)\|[^}]*}", RegexOptions.Compiled);

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return RegexReplace(input, Pattern, "i", "mw-link mw-direct-link");
        }
    }
}