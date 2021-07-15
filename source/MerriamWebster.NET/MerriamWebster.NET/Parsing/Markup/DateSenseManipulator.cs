using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for date sense tokens {ds}.
    /// </summary>
    public class DateSenseManipulator : MarkupManipulator, IMarkupManipulator
    {
        private static readonly Regex Pattern = new Regex(@"{ds\|([^}]*)}", RegexOptions.Compiled);
        
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            var match = Pattern.Match(input);
            if (!match.Success)
            {
                return input;
            }

            input = Regex.Replace(input, Pattern.ToString(), "[x]");
            var index = input.IndexOf("[x]", StringComparison.OrdinalIgnoreCase);

            return input.Substring(0, index);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            var match = Pattern.Match(input);
            if (!match.Success)
            {
                return input;
            }

            input = Regex.Replace(input, Pattern.ToString(), "[x]");

            var target = match.Groups[1].Value;

            var index = input.IndexOf("[x]", StringComparison.OrdinalIgnoreCase);
            string first = input.Substring(0, index);

            var tokens = target.Split('|');
            if (tokens.All(string.IsNullOrEmpty))
            {
                return first;
            }

            first = first + ", defined at sense ";
            string second = string.Empty;
            if (tokens[0].Equals("t", StringComparison.OrdinalIgnoreCase))
            {
                second = "(transitive) ";
            }
            else if (tokens[0].Equals("i", StringComparison.OrdinalIgnoreCase))
            {
                second = "(intransitive) ";
            }

            if (!string.IsNullOrEmpty(tokens[1]))
            {
                tokens[1] = $"<b class=\"mw-b\">{tokens[1]}</b>";
            }

            if (!string.IsNullOrEmpty(tokens[3]))
            {
                tokens[3] = $"({tokens[3]})";
            }

            string third = string.Join("", tokens.Skip(1));


            return first + second + third;
        }
    }
}