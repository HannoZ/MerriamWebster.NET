using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Inflection is the change of form that words undergo to mark such distinctions as case, gender, number, tense, person, mood, or voice.
    /// For instance, the past tense "ran" and present participle "running" are both inflections of the verb "run".
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// If both <see cref="Value"/> and <see cref="Cutback"/> are present, only one should be displayed to the user. The <see cref="Cutback"/> has traditionally been used in print publications. Both are typically displayed in bold.
    /// </para>
    /// <para>
    /// The <see cref="Label"/> is typically displayed in italics, and should be followed by a space.
    /// </para>
    /// <para>
    /// Inflection objects should be separated by a semicolon and space unless the second object of a pair contains <see cref="Label"/>, in which case they should be separated by a space.
    /// </para>
    /// </remarks>
    public class Inflection
    {
        /// <summary>
        /// Gets or sets the inflection label
        /// </summary>
        public string Label { get; set; }
        
        /// <summary>
        /// Gets or sets the inflection cutback.
        /// </summary>
        public string Cutback { get; set; }

        /// <summary>
        /// Gets or sets the inflection value.
        /// </summary>
        public string Value { get; set; }

        ///// <summary>
        ///// Gets or sets the <see cref="AlternateInflection"/>.
        ///// </summary>
        //  public AlternateInflection Alternate { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> This label provides information on the grammatical number (eg, singular, plural) of an inflection in a particular sense.
        /// </summary>
        public string SenseSpecificInflectionPluralLabel { get; set; }
    }
}