namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Usage see in addition reference: contains the text and ID of a "see in addition" reference to another usage section.
    /// </summary>
    /// <remarks>TODO - not yet implemented, requires sample json 
    /// </remarks>
    public class InAdditionReference : IDefiningText
    {
        /// <summary>
        /// Gets or sets the reference text
        /// </summary>
        public string Text { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the reference ID
        /// </summary>
        public string? Id { get; set; }

        /// <inheritdoc />
        public FormattedText MainText => Text;
    }
}