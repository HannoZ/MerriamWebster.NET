namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Contains further detail on quote source (eg, name of larger work in which an essay is found).
    /// </summary>
    public class SubSource
    {
        /// <summary>
        /// Source work for quote.
        /// </summary>
        public FormattedText Source { get; set; }
        /// <summary>
        /// Publication date of quote.
        /// </summary>
        public string PublicationDate { get; set; }

    }
}