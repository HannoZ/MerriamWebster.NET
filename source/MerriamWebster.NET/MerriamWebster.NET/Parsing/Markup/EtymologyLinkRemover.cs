using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupRemover"/> implementation for etymology links (et_link).
    /// </summary>
    public class EtymologyLinkRemover : MarkupRemover, IMarkupRemover
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{et_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}