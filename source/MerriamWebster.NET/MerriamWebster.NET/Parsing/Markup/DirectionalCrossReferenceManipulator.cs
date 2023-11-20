using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for directional cross-reference tokens {dxt|||}.
    /// </summary>
    public partial class DirectionalCrossReferenceManipulator : MarkupManipulator, IMarkupManipulator
    {

#if NET7_0_OR_GREATER

        private static readonly Regex Pattern = ParsePattern();

        [GeneratedRegex(@"{dxt\|([^}|^\|]*)\|.*?}")]
        private static partial Regex ParsePattern();
#else
        // because this element can also contain :, we can't use \S for any non-whitespace character
        // which is a problem if we have a word like 'worn-out'
        private static readonly Regex Pattern = new Regex(@"{dxt\|([^}|^\|]*)\|.*?}", RegexOptions.Compiled);
#endif
        
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
