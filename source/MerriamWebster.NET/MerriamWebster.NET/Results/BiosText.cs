namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Represents text information ("biotext") in a <see cref="BiographicalNote"/>.
    /// </summary>
    public class BiosText : DefiningText
    {
        /// <summary>
        /// Default constructor for deserializing
        /// </summary>
        public BiosText()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="BiosText"/> with the specified text.
        /// </summary>
        public BiosText(string? text) : base(text) {}
    }
}