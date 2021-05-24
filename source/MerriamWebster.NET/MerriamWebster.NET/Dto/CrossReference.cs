namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// When a headword or one of its senses represents a less common spelling or inflected form of another word, the definition is omitted and replaced by a cross-reference pointing to the entry containing detailed definition information.
    /// </summary>
    public class CrossReference
    {
        /// <summary>
        /// Get or sets the cross-reference text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the ID of cross-reference target
        /// </summary>
        public string Target { get; set; }
    }
}