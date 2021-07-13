using System;

namespace MerriamWebster.NET.Dto
{
    /// <inheritdoc cref="IDefiningText"/>
    public class DefiningText : IDefiningText
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefiningText"/> with the specified text.
        /// </summary>
        public DefiningText(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// The definition content
        /// </summary>
        public FormattedText Text { get;  }

        /// <inheritdoc />
        public FormattedText MainText => Text;
    }
}