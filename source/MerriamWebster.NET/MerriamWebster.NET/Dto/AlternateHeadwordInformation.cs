namespace MerriamWebster.NET.Dto
{
    /// <inheritdoc />
    public class AlternateHeadwordInformation : HeadwordInformation
    {
        /// <summary>
        /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        public string ParenthesizedSubjectStatusLabel { get; set; }
    }
}