using System;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing
{
    public static class MarkupRemover
    {
        public static string RemoveMarkupFromString(string input)
        {
            input = input.Replace("{bc}", "")
                .Replace("{dx_def}", "(")
                .Replace("{/dx_def}", ")")
                .Replace("{dx}", "— ")
                .Replace("{/dx}", "")
                .Replace("{dx_ety}", "— ")
                .Replace("{/dx_ety}", "")
                .Replace("{ma}", "— more at ")
                .Replace("{/ma}", "");
            input = input.RemoveOpenCloseTag("b");
            input = input.RemoveOpenCloseTag("it");
            input = input.RemoveOpenCloseTag("inf");
            input = input.RemoveOpenCloseTag("sup");
            input = input.RemoveOpenCloseTag("sc");
            input = input.RemoveOpenCloseTag("wi");
            input = input.ReplaceCrossReferenceTarget();
            input = input.ReplaceAuto_Link();
            input = input.ReplaceDirect_Link();
            input = input.ReplaceItalic_Link();
            input = input.ReplaceEtymology_Link();
            input = input.ReplaceMoreAtTarget();
            input = input.ReplaceSynonymLink();

            return input;
        }

        private static string RemoveOpenCloseTag(this string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }

        private static string ReplaceCrossReferenceTarget(this string input)
        {
            var regex = new Regex(@"{dxt\|([\p{L}]*\s?[\p{L}]*?):?\d?\|*\d?}");

            return RegexReplace(input, regex);
        }

        private static string ReplaceAuto_Link(this string input)
        {
            var regex = new Regex(@"{a_link\|([\p{L}]*)}");

            return RegexReplace(input, regex);
        }


        private static string ReplaceDirect_Link(this string input)
        {
            var regex = new Regex(@"{d_link\|([\p{L}]*)\|[\p{L}]*}");

            return RegexReplace(input, regex);
        }

        private static string ReplaceItalic_Link(this string input)
        {
            var regex = new Regex(@"{i_link\|([\p{L}]*)\|[\p{L}]*}");

            return RegexReplace(input, regex);
        }

        private static string ReplaceEtymology_Link(this string input)
        {
            var regex = new Regex(@"{et_link\|([\p{L}]*)\|[\p{L}]*}");

            return RegexReplace(input, regex);
        }

        private static string ReplaceMoreAtTarget(this string input)
        {
            var regex = new Regex(@"{mat\|([\p{L}]*)\|[\p{L}]*}");

            return RegexReplace(input, regex);
        }

        private static string ReplaceSynonymLink(this string input)
        {
            var regex = new Regex(@"{sx\|([\p{L}]*\s?[\p{L}]*?)\|.*?\|.*?}");

            return RegexReplace(input, regex);
        }


        private static string RegexReplace(string input, Regex regex)
        {
            var matches = regex.Matches(input);
            input = Regex.Replace(input, regex.ToString(), "[x]");

            foreach (Match match in matches)
            {
                var  target = match.Groups[1];

                var index = input.IndexOf("[x]", StringComparison.OrdinalIgnoreCase);
                string first = input.Substring(0, index);
                string last = input.Substring(index + 3);

                input = first +  target + last;
            }

            return input;
        }
    }
}
