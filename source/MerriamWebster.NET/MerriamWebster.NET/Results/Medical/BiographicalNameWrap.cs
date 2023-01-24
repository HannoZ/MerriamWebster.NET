using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results.Medical
{
    /// <summary>
    /// A biographical name wrap groups together personal name, surname, and alternate name information within a biographical entry.
    /// </summary>
    /// <remarks>
    /// <para><i>Medical dictionary only</i></para>
    /// <b>Display Guidance:</b>
    /// <para>
    /// A biographical name wrap is displayed inline and followed by a comma and space.
    /// </para>
    /// <para>
    /// A <see cref="FirstName"/> or <see cref="Surname"/> is typically displayed in normal font.
    /// </para>
    /// <para>
    /// An <see cref="AlternateName"/> is typically displayed in italics.
    /// </para>
    /// </remarks>
    public class BiographicalNameWrap : IDefiningText
    {
        /// <summary>
        /// Personal or first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Alternate name such as pen name, nickname, title, etc.
        /// </summary>
        public string AlternateName { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public FormattedText MainText => AlternateName ?? (FirstName + " " + Surname).Trim();
    }
}