using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupRemover"/> implementation for direct links (d_link).
    /// </summary>
    public class DirectLinkRemover : MarkupRemover, IMarkupRemover
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{d_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}