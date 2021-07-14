using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The sense sequence contains a series of senses and subsenses, ordered by sense numbers beginning at Arabic numeral "1".
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// See <see cref="Sense"/>.
    /// </remarks>
    public class SenseSequence
    {
        /// <summary>
        /// Gets or sets the senses.
        /// </summary>
        public ICollection<SenseSequenceSense> Senses { get; set; } = new List<SenseSequenceSense>();

        ///// <summary>
        ///// The parenthesized sense sequence groups together senses whose sense numbers form a sequence of parenthesized numbers.
        ///// </summary>
        ///// <remarks>
        ///// <b>Display Guidance:</b>
        ///// <para>
        ///// If you are generating sense numbers for sense elements in a sense sequence, put parentheses around the number.
        ///// For example, the second sense in a sequence should have "(2)" as its sense number.
        ///// </para>
        ///// <para>
        ///// f you are instead using the <see cref="Sense.SenseNumber"/> to display the sense number, it will already contain the parentheses.
        ///// </para>
        ///// </remarks>
        //public ICollection<SenseSequence> ParenthesizedSenseSequence { get; set; }
    }
}