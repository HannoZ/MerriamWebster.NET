namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// In addition to the verbal illustrations provided throughout the entry, a larger section of quotations from cited sources is sometimes included. 
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// Gets or sets the quote text.
        /// </summary>
        public FormattedText Text { get; set; } = new ();

        /// <summary>
        /// Gets or sets the attribution of quote information.
        /// </summary>
        public AttributionOfQuote? AttributionOfQuote { get; set; }
    }
}