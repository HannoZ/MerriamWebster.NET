using System;

namespace MerriamWebster.NET.Parsing
{
    public static class MarkupRemover
    {
        public static string RemoveMarkupFromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            input = input.Replace("{bc}", "")
                .Replace("{dx_def}", "(")
                .Replace("{/dx_def}", ")")
                .Replace("{dxt|", "") // TODO not correct
                .Replace("{sx|", "").Replace("||", "");
            input = input.RemoveOpenCloseTag("b");
            input = input.RemoveOpenCloseTag("it");
            input = input.RemoveOpenCloseTag("inf");
            input = input.RemoveOpenCloseTag("sup");
            input = input.RemoveOpenCloseTag("sc");
            input = input.RemoveOpenCloseTag("wi")

                .Replace("{a_link|", "")
                .Replace("{d_link||", "") // TODO not correct
                .Replace("{i_link||", "") // TODO not correct
                .Replace("{et_link||", "") // TODO not correct
                .Replace("{mat||", "") // TODO not correct
                .Replace("}", ""); // replace any trailing } characters

            return input.Trim();
        }
        
        private static string RemoveOpenCloseTag(this string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }
    }
}
