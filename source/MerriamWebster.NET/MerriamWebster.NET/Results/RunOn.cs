using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    ///  A base class for (un)defined run-ons with properties that occur on both classes
    /// </summary>
    public abstract class RunOn
    {
        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation> Pronunciations { get; set; }


        /// <summary>
        /// Describes the grammatical function of a headword or undefined entry word. It indicates the role the word plays in a sentence, such as "noun", "verb", "adjective", etc.<br/>
        /// It may also categorize the word in other ways, such as "trademark" or "abbreviation". 
        /// </summary>
        /// <remarks>
        /// Also called 'functional label'.<br/>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics
        /// </remarks>
        public Label PartOfSpeech { get; set; }

        /// <summary>
        /// <i>Optional.</i> A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Display within parentheses and in italics.
        /// </remarks>
        public Label ParenthesizedSubjectStatusLabel { get; set; }

        /// <summary>
        /// <i>Optional.</i>  General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
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
        /// <i>Optional.</i>  Gets or sets variants.
        /// </summary>
        public ICollection<Variant> Variants { get; set; }
    }
}