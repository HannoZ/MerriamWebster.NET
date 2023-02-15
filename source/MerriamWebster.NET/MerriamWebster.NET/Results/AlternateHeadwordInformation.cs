namespace MerriamWebster.NET.Results
{
    /// <inheritdoc />
    public class AlternateHeadwordInformation : HeadwordInformation
    {
        /// <summary>
        /// <i>Optional.</i> A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b> Display within parentheses and in italics.
        /// </remarks>
        public ParenthesizedSubjectStatusLabel? ParenthesizedSubjectStatusLabel { get; set; }

        /// <summary>
        /// <i>Spanish-English only.</i> Contains a cutback form of the preceding alternate headword.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In bilingual dictionaries, an alternate headword often simply presents the main headword in a different gender and/or number (eg, in its feminine singular or masculine plural form).
        /// In space-constrained environments, such alternate headwords may be presented in a shortened cutback form (eg, "-ga").
        /// </para>
        /// <b>Display Guidance: </b>Typically displayed in bold.
        /// <para>
        /// Note that the <see cref="HeadwordCutback"/> is simply a shortened form of the immediately preceding <see cref="HeadwordInformation.Text"/>;
        /// only one of these two elements should be presented to the user at a time.
        /// </para>
        /// </remarks>
        public string? HeadwordCutback { get; set; }
    }
}