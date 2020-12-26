using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class DirectLinkRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{d_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}