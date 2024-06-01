using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The definition section groups together all sense sequences and verb dividers for a headword or defined run-on phrase.
    /// We refer to the definition section for the headword itself as the main definition section.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// Typically displayed in a new paragraph.
    /// </para>
    /// </remarks>
    public class Definition
    {
        /// <summary>
        /// The verb divider acts as a functional label in verb entries, introducing the separate sense sequences for transitive and intransitive meanings of the verb.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics
        /// </remarks>
        public string? VerbDivider { get; set; }

        /// <summary>
        /// Gets or sets the sense sequences.
        /// </summary>
        public ICollection<SenseSequence> SenseSequence { get; set; } = [];
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets a collection of synonyms.
        /// </summary>
        public ICollection<string>? Synonyms { get; set; }
        /// <summary>
        /// <i>Optional.</i> Gets or sets a collection of antonyms.
        /// </summary>
        public ICollection<string>? Antonyms { get; set; }

        /// <summary>
        /// <i>Optional.</i>  A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<SubjectStatusLabel>? SubjectStatusLabels { get; set; }
    }
}