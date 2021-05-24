using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupRemover"/> implementation for auto links (a_link).
    /// </summary>
    public class AutoLinkRemover : MarkupRemover, IMarkupRemover
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{a_link\|([^}]*)}");

            return RegexReplace(input, regex);
        }
    }
}