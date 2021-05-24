namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// Defines an interface for classes that perform some specific markup removal.
    /// </summary>
    public interface IMarkupRemover
    {
        /// <summary>
        /// Removes markup.
        /// </summary>
        /// <remarks>
        /// Each kind of markup should be removed by a specific class that implements this interface.
        /// </remarks>
        /// <param name="input">The input text.</param>
        /// <returns>The input text with markup removed.</returns>
        string RemoveMarkup(string input);
    }
}