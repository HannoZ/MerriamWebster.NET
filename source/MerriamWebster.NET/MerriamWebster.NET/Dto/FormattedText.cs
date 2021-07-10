using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Contains raw text, formatted text (with MW-markup removed) and HTML-formatted text
    /// </summary>
    public class FormattedText
    {
        /// <summary>
        /// Creates a default instance of the <see cref="FormattedText"/> class.
        /// </summary>
        public FormattedText()
        {
            
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FormattedText"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="options">The parse options.</param>
        public FormattedText(string text, ParseOptions options)
        {
            RawText = text;
            Text = options.RemoveMarkup ? MarkupManipulator.RemoveMarkupFromString(text) : text;
            HtmlText = options.ReplaceMarkup ? MarkupManipulator.ReplaceMarkupInString(text) : text;
        }

        /// <summary>
        /// Contains the raw text (with MW-markup) as it comes from the source.
        /// </summary>
        public string RawText { get;  }

        /// <summary>
        /// Contains the text.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted text. The <see cref="RawText"/> still contains the unformatted text. 
        /// </para>
        /// </remarks>
        public string Text { get;  }

        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to replace markup, this contains the text with MW-specific markup replaced by HTML markup.
        /// The <see cref="RawText"/> still contains the unformatted text. 
        /// </summary>
        public string HtmlText { get;  }

        public override string ToString()
        {
            return Text;
        }
    }
}