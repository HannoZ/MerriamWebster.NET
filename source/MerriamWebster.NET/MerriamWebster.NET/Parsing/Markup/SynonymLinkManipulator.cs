using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for synonym links (sx).
    /// </summary>
    public class SynonymLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{sx\|([^}]*)\|.*?\|.*?}");

            return RegexReplace(input, regex);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return input;
        }
    }
}