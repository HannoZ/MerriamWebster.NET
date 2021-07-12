using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Contains properties that both exist on <see cref="Sense"/> and <see cref="DividedSense"/>.
    /// </summary>
    public class SenseBase
    {
        /// <summary>
        /// Gets or sets the defining texts.
        /// </summary>
        public ICollection<IDefiningText> DefiningTexts { get; set; } = new List<IDefiningText>();

        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the variants.
        /// </summary>
        public ICollection<Variant> Variants { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection> Inflections { get; set; }

        /// <summary>
        /// <i>Optional.</i> General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<Label> GeneralLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i> A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<Label> SubjectStatusLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i> This label notes whether a particular sense of a verb is transitive (T) or intransitive (I). 
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically displayed within square brackets and in italics.
        /// </remarks>
        public Label SenseSpecificGrammaticalLabel { get; set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology.
        /// </summary>
        public Etymology Etymology { get; set; }

    }
}