namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
    /// </remarks>
    public class GeneralLabel : Label
    {
        /// <inheritdoc />
        public GeneralLabel()
        {
            
        }

        /// <inheritdoc />
        public GeneralLabel(string text) : base(text)
        {
            
        }
    }
}