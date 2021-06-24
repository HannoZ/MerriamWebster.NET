namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Direct quotes are used in both verbal illustrations and end-of-entry quotation sections.
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// Gets or sets the quote text.
        /// </summary>
        public string Text { get; set; }
        public string HtmlText { get; set; }
        public string RawText { get; set; }
        /// <summary>
        /// Name of author.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Source work for quote.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Publication date of quote.
        /// </summary>
        public string PublicationDate { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Subsource"/>.
        /// </summary>
        public SubSource Subsource { get; set; }
    }
}