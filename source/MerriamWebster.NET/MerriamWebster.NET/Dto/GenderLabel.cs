using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// <i>Optional, Spanish-English only</i> In a bilingual dictionary, a gender label provides the grammatical gender for the immediately preceding translation of the headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically displayed in italics.
    /// </remarks>
    public class GenderLabel : IDefiningText
    {
        /// <summary>
        /// Default constructor for deserializing
        /// </summary>
        public GenderLabel()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="GenderLabel"/> class with specified label. 
        /// </summary>
        public GenderLabel(string label)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public Label Label { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public FormattedText MainText => Label.Text;
    }
}