namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// <i>Optional, Spanish-English only</i> n bilingual dictionaries, a headword translation may have multiple forms for different grammatical genders.
    /// In digital formats such forms are spelled out, while in space-constrained environments they may be presented in shortened cutback form.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically displayed in normal font.
    /// <para>
    /// Note: as the <see cref="GenderWordCutback"/> is simply a shortened form of the immediately following <see cref="GenderWordSpelledOut"/>,
    /// only one of these two elements should be presented to the user at a time.
    /// </para>
    /// </remarks>
    public class GenderForms : IDefiningText
    {
        /// <summary>
        /// text of gender word cutback form.
        /// </summary>
        public string GenderWordCutback { get; set; }
        /// <summary>
        /// text of gender word spelled-out form.
        /// </summary>
        public string GenderWordSpelledOut { get; set; }
    }
}