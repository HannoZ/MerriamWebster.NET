using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for italic links (i_link).
    /// </summary>
    public class ItalicLinkManipulator : MarkupManipulator, IMarkupManipulator
    {

        private static readonly Regex Pattern = new Regex(@"{i_link\|([^}]*)\|[^}]*}", RegexOptions.Compiled);

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return RegexReplace(input, Pattern, "i", "mw-link mw-italic-link");
        }
    }
}