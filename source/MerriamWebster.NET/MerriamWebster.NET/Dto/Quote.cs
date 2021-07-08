namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// In addition to the verbal illustrations provided throughout the entry, a larger section of quotations from cited sources is sometimes included. 
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
        /// Gets or sets the attribution of quote information.
        /// </summary>
        public AttributionOfQuote AttributionOfQuote { get; set; }
    }
}