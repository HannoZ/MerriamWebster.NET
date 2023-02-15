namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Describes the grammatical function of a headword or undefined entry word. It indicates the role the word plays in a sentence, such as "noun", "verb", "adjective", etc.<br/>
    /// It may also categorize the word in other ways, such as "trademark" or "abbreviation". 
    /// </summary>
    /// <remarks>
    /// Also called 'part of speech'.<br/>
    /// <b>Display Guidance:</b>
    /// Typically rendered in italics
    /// </remarks>
    public class FunctionalLabel : Label
    {

        /// <inheritdoc />
        public FunctionalLabel()
        {
            
        }

        /// <inheritdoc />
        public FunctionalLabel(string text) : base(text)
        {
            
        }
    }
}