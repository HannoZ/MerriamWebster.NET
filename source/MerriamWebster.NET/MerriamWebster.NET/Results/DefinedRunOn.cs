using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A defined run-on phrase is an expression or phrasal verb formed from the headword.
    /// This phrase, its definition section, and other information such as pronunciations, together make up a defined run-on.
    /// A set of defined run-ons can follow (or "run on" from) the entry's main def definition section, with each such run-on containing a defined run-on phrase.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Each defined run-on is typically displayed in a new paragraph. <br/>
    /// The <see cref="Phrase"/> is displayed in bold and preceded by an em-dash.
    /// </remarks>
    public class DefinedRunOn : RunOn
    {
        /// <summary>
        /// defined run-on phrase
        /// </summary>
        public string Phrase { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the definitions.
        /// </summary>
        public ICollection<Definition>? Definitions { get; set; } = new List<Definition>();
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology.
        /// </summary>
        public Etymology? Etymology { get; set; }
    }


}