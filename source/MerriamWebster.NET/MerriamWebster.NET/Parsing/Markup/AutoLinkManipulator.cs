using System;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for auto links (a_link).
    /// </summary>
    public class AutoLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
        private static readonly Regex Pattern = new Regex(@"{a_link\|([^}]*)}", RegexOptions.Compiled);

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return RegexReplace(input, Pattern, "i", "mw-link mw-auto-link");
        }
    }
}