namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// This label notes whether a particular sense of a verb is transitive (T) or intransitive (I). 
    /// </summary>
    /// <remarks>
    /// The sense-specific grammatical label is contained in an "sgram".<br/>
    /// <b>Display Guidance:</b>
    /// Typically displayed within square brackets and in italics.
    /// </remarks>
    public class SenseSpecificGrammaticalLabel : Label
    {
        /// <inheritdoc />
        public SenseSpecificGrammaticalLabel()
        {
            
        }

        /// <inheritdoc />
        public SenseSpecificGrammaticalLabel(string text) : base(text)
        {
            
        }
    }
}