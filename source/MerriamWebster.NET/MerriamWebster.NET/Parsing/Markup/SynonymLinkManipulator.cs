using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for synonym links (sx).
    /// </summary>
    public class SynonymLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
        private static readonly Regex Pattern = new Regex(@"{sx\|([^}]*)\|.*?\|.*?}", RegexOptions.Compiled);
        
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return input;
        }
    }
}