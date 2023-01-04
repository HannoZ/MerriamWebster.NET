namespace MerriamWebster.NET.Results
{
    /// <inheritdoc />
    public class AlternateHeadwordInformation : HeadwordInformation
    {
        /// <summary>
        /// Contains a cutback form of the preceding alternate headword.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In bilingual dictionaries, an alternate headword often simply presents the main headword in a different gender and/or number (eg, in its feminine singular or masculine plural form).
        /// In space-constrained environments, such alternate headwords may be presented in a shortened cutback form (eg, "-ga").
        /// </para>
        /// <b>Display Guidance:</b>
        /// <para>Typically displayed in bold.</para>
        /// <para>
        /// Note that the <see cref="HeadwordCutback"/> is simply a shortened form of the immediately preceding <see cref="HeadwordInformation.Text"/>;
        /// only one of these two elements should be presented to the user at a time.
        /// </para>
        /// </remarks>
        public string HeadwordCutback { get; set; }
    }
}