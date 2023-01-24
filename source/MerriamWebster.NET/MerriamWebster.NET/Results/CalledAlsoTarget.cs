using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A called-also note target.
    /// </summary>
    public class CalledAlsoTarget
    {
        /// <summary>
        /// Called-also target text
        /// </summary>
        public string TargetText { get; set; }

        /// <summary>
        /// Called-also reference containing target ID
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// parenthesized number
        /// </summary>
        public string ParenthesizedNumber { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the parenthesized subject/status label.
        /// </summary>
        public ParenthesizedSubjectStatusLabel ParenthesizedSubjectStatusLabel { get; set; }

        public override string ToString()
        {
            // TODO use the other properties as well 

            return TargetText;
        }
    }
}