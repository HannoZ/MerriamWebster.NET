using System.Collections.Generic;
using System.Linq;

namespace MerriamWebster.NET.Dto
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
    public class Definition
    {
        /// <summary>
        /// The verb divider acts as a functional label in verb entries, introducing the separate sense sequences for transitive and intransitive meanings of the verb.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics
        /// </remarks>
        public string VerbDivider { get; set; }

        /// <summary>
        /// Gets or sets the senses.
        /// </summary>
        public ICollection<Sense> SenseSequence { get; set; } = new List<Sense>();

        /// <summary>
        /// The parenthesized sense sequence groups together senses whose sense numbers form a sequence of parenthesized numbers.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// <para>
        /// If you are generating sense numbers for sense elements in a sense sequence, put parentheses around the number.
        /// For example, the second sense in a sequence should have "(2)" as its sense number.
        /// </para>
        /// <para>
        /// f you are instead using the <see cref="Sense.SenseNumber"/> to display the sense number, it will already contain the parentheses.
        /// </para>
        /// </remarks>
        public ICollection<Sense> ParenthesizedSenseSequence { get; set; }

        /// <summary>
        /// Gets or sets a collection of synonyms.
        /// </summary>
        public ICollection<string> Synonyms { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets a collection of antonyms.
        /// </summary>
        public ICollection<string> Antonyms { get; set; } = new List<string>();


        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<Label> SubjectStatusLabels { get; set; }
    }
}