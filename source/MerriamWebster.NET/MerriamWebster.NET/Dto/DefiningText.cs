using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Dto
{
    /// <inheritdoc cref="IDefiningText"/>
    public class DefiningText : IDefiningText
    {
        /// <summary>
        /// Default constructor for deserializing
        /// </summary>
        public DefiningText()
        {
        }

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
        public FormattedText Text { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public FormattedText MainText => Text;

        public string Type { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Text == null ? base.ToString() : Text.ToString();
        }
    }
}