namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The defining text is the text of the definition or translation for a particular sense.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The defining text is a collection that usually starts with a "text" object (<see cref="DefiningText"/>) that contains the main definition.
    /// There are a number of other types that together form the entire definition. 
    /// </para>
    /// <para>
    /// <b>Display Guidance:</b>
    /// Inline in normal font
    /// </para>
    /// </remarks>
    public interface IDefiningText
    {
        /// <summary>
        /// Gets the main defining text.
        /// </summary>
        FormattedText MainText { get; }
    }
}