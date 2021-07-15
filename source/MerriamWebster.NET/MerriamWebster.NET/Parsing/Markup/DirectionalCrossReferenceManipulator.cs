using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for directional cross-reference tokens {dxt|||}.
    /// </summary>
    internal class DirectionalCrossReferenceManipulator : MarkupManipulator, IMarkupManipulator
    {
        // because this element can also contain :, we can't use \S for any non-whitespace character
        // which is a problem if we have a word like 'worn-out'
        private static readonly Regex Regex = new Regex(@"{dxt\|([^}|^\|]*)\|.*?}", RegexOptions.Compiled);

        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Regex);
        }

        public string ReplaceMarkup(string input)
        {
            return input;
        }
    }
}
