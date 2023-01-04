using System.Collections.Generic;

namespace MerriamWebster.NET.Results
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
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection> Inflections { get; set; }

        /// <summary>
        /// <i>Optional, Spanish-English only.</i> Gets or sets an alternate undefinied entry word.
        /// </summary>
        public AlternateUndefinedEntryWord AlternateEntry { get; set; }
    }
}