namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Represents date information ("biodate") in a <see cref="BiographicalNote"/>.
    /// </summary>
    public class BiosDate : DefiningText
    {
        /// <summary>
        /// Default constructor for deserializing
        /// </summary>
        public BiosDate()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="BiosDate"/> with the specified text.
        /// </summary>
        public BiosDate(string? text) : base(text) {}
    }
}