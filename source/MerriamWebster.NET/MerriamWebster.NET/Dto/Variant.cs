using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A variant is a different spelling or styling of a headword, defined run-on phrase, or undefined entry word.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// A set of variants might be displayed inline with the headword, or in its own block with a lead-in heading such as "variants:".<br/>
    /// Each variant is typically displayed in bold, less prominently than a headword.<br/><br/>
    /// A label is typically displayed in italics.
    /// </remarks>
    public class Variant
    {
        /// <summary>
        /// <i>Optional.</i> Variant label, such as “or”.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the variant text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// <i>Spanish-English only.</i> <i>Optional.</i> Contains a cutback form of the preceding variant.
        /// </summary>
        /// <remarks>
        /// A variant is often a sense-specific idiom or phrase containing the headword. In space-constrained environments, such variants may be presented in a shortened cutback form that omits the headword itself. 
        /// </remarks>
        public string Cutback { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> This label provides information on the grammatical number (eg, singular, plural) of an inflection in a particular sense.
        /// </summary>
        public Label SenseSpecificInflectionPluralLabel { get; set; }
    }
}