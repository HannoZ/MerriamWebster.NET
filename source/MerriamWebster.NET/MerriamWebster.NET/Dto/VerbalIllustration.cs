namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A verbal illustration is an example sentence illustrating how a word is used in context.
    /// It may either be a made-up sentence or a quotation from a cited source.
    /// While the verbal illustration typically exemplifies usage for a particular sense of a headword or defined run-on phrase,
    /// it may also be associated with other elements of an entry such as a set of synonyms, supplemental note in an etymology, or undefined run-on.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// A verbal illustration is typically set off from surrounding text (as by surrounding the entire illustration in angle brackets).
    /// </para>
    /// In the Spanish-English dictionary, examples are short sentences that illustrate the use of the headword.<br/>
    /// For other dictionaries, so called 'variants' or other text that further illustrates the definition are returned as example.
    /// In that case the <see cref="Translation"/> property will always be null.
    /// Sometimes a <see cref="Quote"/> may also be present if the text was cited from some source.
    /// </remarks>
    public class VerbalIllustration : IDefiningText
    {
        /// <summary>
        /// Gets or sets the sentence.
        /// </summary>
        public FormattedText Sentence { get; set; } = new FormattedText();

        /// <summary>
        /// <i>Only used in Spanish-English dictionary.</i>
        /// The translation of the <see cref="Sentence"/>.
        /// </summary>
        /// <remarks>Spanish-English only.</remarks>
        public string Translation { get; set; }
        /// <summary>
        /// Gets or sets the attribution of quote information.
        /// </summary>
        public AttributionOfQuote AttributionOfQuote { get; set; }

        /// <inheritdoc />
        public FormattedText MainText => Sentence;
    }
}