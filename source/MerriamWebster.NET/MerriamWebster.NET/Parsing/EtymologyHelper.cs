using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Parsing
{
    public class EtymologyHelper
    {
        public static Etymology Parse(Response.Etymology[][] source, ParseOptions options)
        {
            var etymology = new Etymology();
            if (source[0][0].TypeOrText == "text")
            {
                string text =  source[0][1].TypeOrText;
                etymology.Text = new FormattedText(text, options);
            }

            if (source.Length > 1 && source[1][0].TypeOrText == "et_snote")
            {
                var content = source[1][1].Content;
                string text = content[0][1];

                etymology.Note = new FormattedText(text, options);
            }

            return etymology;
        }
    }
}