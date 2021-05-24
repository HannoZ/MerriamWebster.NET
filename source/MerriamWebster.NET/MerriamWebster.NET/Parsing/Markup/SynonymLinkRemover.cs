using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupRemover"/> implementation for synonym links (sx).
    /// </summary>
    public class SynonymLinkRemover : MarkupRemover, IMarkupRemover
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{sx\|([^}]*)\|.*?\|.*?}");

            return RegexReplace(input, regex);
        }
    }
}