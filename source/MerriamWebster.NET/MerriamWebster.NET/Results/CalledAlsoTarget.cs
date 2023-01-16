using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A called-also note target.
    /// </summary>
    public class CalledAlsoTarget
    {
        /// <summary>
        /// called-also target text
        /// </summary>
        public string TargetText { get; set; }
        /// <summary>
        /// called-also reference containing target ID
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// parenthesized number
        /// </summary>
        public string ParenthesizedNumber { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets a collection of pronunciations.
        /// </summary>
        /// <remarks>Usually there is only 1 pronunciation</remarks>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Display within parentheses and in italics.
        /// </remarks>
        public ParenthesizedSubjectStatusLabel ParenthesizedSubjectStatusLabel { get; set; }

        public override string ToString()
        {
            // TODO use the other properties as well 

            return TargetText;
        }
    }
}