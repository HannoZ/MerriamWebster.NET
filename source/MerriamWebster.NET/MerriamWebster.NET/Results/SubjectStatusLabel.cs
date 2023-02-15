namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
    /// </remarks>
    public class SubjectStatusLabel : Label
    {
        /// <inheritdoc />
        public SubjectStatusLabel()
        {
            
        }

        /// <inheritdoc />
        public SubjectStatusLabel(string text) : base(text)
        {
            
        }
    }
}