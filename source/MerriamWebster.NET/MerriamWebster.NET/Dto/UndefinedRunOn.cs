using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// An undefined entry word is derived from or related to the headword, carries a functional label and possibly other information, but does not have any definitions.<br/>
    /// A set of <see cref="UndefinedRunOn"/>s can follow (or "run on" from) the entry's main def definition section, with each such run-on containing an <see cref="EntryWord"/>.
    /// </summary>
    public class UndefinedRunOn : RunOn
    {
        /// <summary>
        /// Undefined entry word
        /// </summary>
        public string EntryWord { get; set; }

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

        ///// <summary>
        ///// Undefined run-on text section containing vis and/or uns elements
        ///// </summary>
        //public DefiningTextComplexTypeWrapper[][] TextSection { get; set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection> Inflections { get; set; }


        // TODO spanish english only
        ///// <summary>
        ///// Gets or sets an <see cref="AlternateUndefinedEntryWord"/>.
        ///// </summary>
        //public AlternateUndefinedEntryWord AlternateEntry { get; set; }
    }
}