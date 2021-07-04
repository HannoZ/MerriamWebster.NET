namespace MerriamWebster.NET.Parsing.Markup
{
    internal class OpenCloseTagMarkupManipulator : IMarkupManipulator
    {
        private readonly string[] _tags = {"b", "it", "inf", "sup", "sc", "wi", "phrase", "qword", "parahw" };

        public string RemoveMarkup(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            foreach (var tag in _tags)
            {
                input = RemoveOpenCloseTag(input, tag);
            }

            return input;
        }

        public string ReplaceMarkup(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            input = ReplaceOpenCloseTag(input, "b", "b");
            input = ReplaceOpenCloseTag(input, "it", "i");
            input = input.Replace("{phrase}", "<span class=\"mw-phrase\"><b><i>")
                .Replace("{/phrase}", "</b></i></span>");
            input = ReplaceOpenCloseTag(input, "qword", "i");
            input = ReplaceOpenCloseTag(input, "parahw", "i");
            input = ReplaceOpenCloseTag(input, "wi", "i");
            input = ReplaceOpenCloseTag(input, "inf", "sub");
            input = ReplaceOpenCloseTag(input, "sup", "sup");
            input = input.Replace("{sc}", "<span class=\"mw-sc\" style=\"font-variant: small-caps\">")
                    .Replace("{/sc}", "</span>")
                ;


            return input;
        }

        private static string RemoveOpenCloseTag(string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }

        private static string ReplaceOpenCloseTag(string input, string tag, string replacement)
        {
            return input.Replace($"{{{tag}}}", $"<{replacement} class=\"mw-{tag}\">")
                .Replace($"{{/{tag}}}", $"</{replacement}>");
        }
    }
}