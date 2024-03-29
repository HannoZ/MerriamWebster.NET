﻿using System;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results
{
    /// <inheritdoc cref="IDefiningText"/>
    public class DefiningText : IDefiningText
    {
        /// <summary>
        /// Default constructor for deserializing
        /// </summary>
        public DefiningText()
        {
            Text = new FormattedText();
        }

        /// <summary>
        /// Creates a new instance of <see cref="DefiningText"/> with the specified text.
        /// </summary>
        public DefiningText(string? text)
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
        
        /// <inheritdoc />
        public override string ToString()
        {
            var toString = Text == string.Empty ? base.ToString() : Text.ToString();
            return toString ?? string.Empty;
        }
    }
}