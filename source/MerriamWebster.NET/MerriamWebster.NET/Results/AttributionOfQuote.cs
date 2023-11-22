namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Direct quotes are used in both verbal illustrations and end-of-entry quotation sections.
    /// Information about the attribution (the author, publication, date, etc.) of a particular quote is contained in this class.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>The quote is typically preceded by an em-dash.</para>
    /// <para>
    /// Each instance of <see cref="Author"/>, <see cref="Source"/>, <see cref="PublicationDate"/>, should be followed by a comma and space.
    /// </para>
    /// </remarks>
    public class AttributionOfQuote
    {
        /// <summary>
        /// Name of author.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Source work for quote.
        /// </summary>
        public FormattedText? Source { get; set; }

        /// <summary>
        /// Publication date of quote.
        /// </summary>
        public string? PublicationDate { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Subsource"/>.
        /// </summary>
        public SubSource? Subsource { get; set; }

        public FormattedText AttributionText
        {
            get
            {
                var text = Author;
                if (Source != null)
                {
                    text += $", {Source.RawText}";
                }

                if (PublicationDate != null)
                {
                    text += $", {PublicationDate}";
                }

                if (Subsource != null)
                {
                    if (!string.IsNullOrEmpty(Subsource.Source.RawText))
                    {
                        text += $", {Subsource.Source.RawText}";
                    }

                    if (Subsource.PublicationDate != null)
                    {
                        text += $", {Subsource.PublicationDate}";
                    }
                }

                return new FormattedText(text);
            }
        }
    }
}