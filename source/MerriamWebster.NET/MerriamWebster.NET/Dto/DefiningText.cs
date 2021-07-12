using System;

namespace MerriamWebster.NET.Dto
{
    /// <inheritdoc cref="IDefiningText"/>
    public class DefiningText : IDefiningText
    {
        public DefiningText(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// The definition content
        /// </summary>
        public FormattedText Text { get; set; } 
    }
}