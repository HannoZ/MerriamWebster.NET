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
        /// <remarks>
        /// With default parse settings, markup is removed. The <see cref="RawText"/> property contains the raw response text from the api. 
        /// </remarks>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the quote text, with markup replaced by HTML markup.
        /// </summary>
        public string HtmlText { get; set; }
        /// <summary>
        /// Gets or sets the raw quote text (with 
        /// </summary>
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