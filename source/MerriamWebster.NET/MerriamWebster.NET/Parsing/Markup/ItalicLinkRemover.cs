using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupRemover"/> implementation for italic links (i_link).
    /// </summary>
    public class ItalicLinkRemover : MarkupRemover, IMarkupRemover
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{i_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}