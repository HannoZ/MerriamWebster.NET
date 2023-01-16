namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
    /// </summary>
    /// <remarks>
    /// The parenthesized subject/status label is contained in a "psl".<br/>
    /// <b>Display Guidance:</b>
    /// Display within parentheses and in italics.
    /// </remarks>
    public class ParenthesizedSubjectStatusLabel : Label
    {
        /// <inheritdoc />
        public ParenthesizedSubjectStatusLabel()
        {
            
        }

        /// <inheritdoc />
        public ParenthesizedSubjectStatusLabel(string text) : base(text)
        {
            
        }
    }
}