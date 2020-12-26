using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class MoreAtTargetRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{mat\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}