namespace MerriamWebster.NET.Parsing
{
    public static class MarkupRemover
    {
        public static string RemoveMarkupFromString(string input)
        {
            string translation = input.Replace("{bc}", "")
                .Replace("{dx_def}", "(")
                .Replace("{/dx_def}", ")")
                .Replace("{dxt|", "") // TODO not correct
                .Replace("{sx|", "").Replace("||", ":");
            translation = translation.RemoveOpenCloseTag("b");
            translation = translation.RemoveOpenCloseTag("it");
            translation = translation.RemoveOpenCloseTag("inf");
            translation = translation.RemoveOpenCloseTag("sup");
            translation = translation.RemoveOpenCloseTag("sc");
            translation = translation.RemoveOpenCloseTag("wi")

                .Replace("{a_link|", "")
                .Replace("{d_link||", "") // TODO not correct
                .Replace("{i_link||", "") // TODO not correct
                .Replace("{et_link||", "") // TODO not correct
                .Replace("{mat||", "") // TODO not correct
                .Replace("}", ""); // replace any trailing } characters

            return translation;
        }



        private static string RemoveOpenCloseTag(this string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }
    }
}
