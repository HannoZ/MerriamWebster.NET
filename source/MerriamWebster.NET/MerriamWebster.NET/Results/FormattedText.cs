using System.Text.Json.Serialization;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Contains raw text, formatted text (with MW-markup removed) and HTML-formatted text
    /// </summary>
    public class FormattedText
    {
        /// <summary>
        /// Creates a default instance of the <see cref="FormattedText"/> class. 
        /// </summary>
        /// <remarks>Required for deserialization</remarks>
        public FormattedText()
        {
            RawText = string.Empty;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FormattedText"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public FormattedText(string? text)
        {
            RawText = text ?? string.Empty;
        }

        /// <summary>
        /// Contains the raw text (with MW-markup) as it comes from the source.
        /// </summary>
        public string RawText { get; set; }

        /// <summary>
        /// Contains the text.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted text. The <see cref="RawText"/> still contains the unformatted text. 
        /// </para>
        /// </remarks>
        [JsonIgnore]
        public string Text => MarkupManipulator.RemoveMarkupFromString(RawText);

        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to replace markup, this contains the text with MW-specific markup replaced by HTML markup.
        /// The <see cref="RawText"/> still contains the unformatted text. 
        /// </summary>
        [JsonIgnore]
        public string HtmlText => MarkupManipulator.ReplaceMarkupInString(RawText);

        /// <summary>
        /// Creates a new <see cref="FormattedText"/> instance from the input string.
        /// </summary>
        public static implicit operator FormattedText(string? text)
        {
            return new FormattedText(text);
        }

        /// <summary>
        /// Takes a FormattedText object and returns the <see cref="RawText"/> value. 
        /// </summary>
        public static implicit operator string?(FormattedText? text)
        {
            return text?.RawText;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Text;
        }
    }
}