namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// Defines methods for markup manipulation.
    /// </summary>
    internal interface IMarkupManipulator
    {
        /// <summary>
        /// Removes all MW-specific markup from the input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        string RemoveMarkup(string input);
        /// <summary>
        /// Replaces all MW-specific markup with HTML markup, when applicable, or removes the markup.
        /// </summary>
        /// <param name="input">The input string.</param>
        string ReplaceMarkup(string input);
    }

}