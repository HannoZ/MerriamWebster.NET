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
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection> Inflections { get; set; }

        /// <summary>
        /// <i>Optional, Spanish-English only.</i> Gets or sets an alternate undefinied entry word.
        /// </summary>
        public AlternateUndefinedEntryWord AlternateEntry { get; set; }
    }

    /// <summary>
    /// In bilingual dictionaries, an undefined entry word may have multiple forms according to grammatical gender and number. 
    /// In digital formats such forms are spelled out, while in space-constrained environments they may be presented in shortened cutback form.
    /// An alternate undefined entrycontains an undefined entry word cutback in <see cref="TextCutback"/> as well as a spelled-out undefined entry word in <see cref="Text"/>.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// The first <see cref="Text"/> is preceded by an em-dash.
    /// </para>
    /// <para>
    /// Both <see cref="TextCutback"/> and <see cref="Text"/> are displayed in bold.
    /// </para>
    /// <para>
    /// Separate a series of <see cref="UndefinedRunOn.EntryWord"/> and <see cref="AlternateUndefinedEntryWord"/> elements with a comma and space.
    /// </para>
    /// <para>
    /// Note: within an <see cref="AlternateUndefinedEntryWord"/> the <see cref="TextCutback"/> is simply a shortened form of the immediately following <see cref="Text"/>, so only one of these two elements should be presented to the user at a time.
    /// </para>
    /// </remarks>
    public class AlternateUndefinedEntryWord
    {
        /// <summary>
        /// Text of undefined entry word cutback form
        /// </summary>
        public string TextCutback { get; set; }

        /// <summary>
        /// Text of undefined entry word spelled-out form
        /// </summary>
        public string Text { get; set; }
    }
}