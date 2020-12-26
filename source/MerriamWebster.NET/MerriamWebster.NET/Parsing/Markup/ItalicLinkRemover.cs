using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class ItalicLinkRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{i_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}