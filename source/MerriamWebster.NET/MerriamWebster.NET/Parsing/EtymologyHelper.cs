using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    internal static class EtymologyHelper
    {
        /// <summary>
        /// Parses the source <see cref="Response.Etymology"/> array to an <see cref="Etymology"/> object
        /// </summary>
        public static Etymology ParseEtymology(this Response.Etymology[][] source)
        {
            var etymology = new Etymology();
            if (source[0][0].TypeOrText == "text")
            {
                string text =  source[0][1].TypeOrText;
                etymology.Text = text;
            }

            if (source.Length > 1 && source[1][0].TypeOrText == "et_snote")
            {
                var content = source[1][1].Content;
                string text = content[0][1];

                etymology.Note = text;
            }

            return etymology;
        }
    }
}