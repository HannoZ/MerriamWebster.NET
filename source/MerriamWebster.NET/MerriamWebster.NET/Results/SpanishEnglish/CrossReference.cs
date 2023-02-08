namespace MerriamWebster.NET.Results.SpanishEnglish
{
    /// <summary>
    /// <i>Spanish-English only.</i> When a headword or one of its senses represents a less common spelling or inflected form of another word, the definition is omitted and replaced by a cross-reference pointing to the entry containing detailed definition information.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// The cross-reference is preceded by a right-pointing arrow.<br/>
    /// The cross-reference should be used to generate a hyperlink, with link text provided by <see cref="Text"/>.
    /// If there is more than one cross-reference, they are separated by a comma and space.
    /// </remarks>
    public class CrossReference
    {
        /// <summary>
        /// Get or sets the cross-reference text
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of cross-reference target
        /// </summary>
        public string Target { get; set; } = string.Empty;
    }
}