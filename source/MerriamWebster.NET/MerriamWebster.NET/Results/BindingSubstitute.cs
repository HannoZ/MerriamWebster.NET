namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A broad, general sense introducing a series of senses that give more contextual and specific meanings.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Inline in normal font
    /// </remarks>
    /// <example>
    /// This sense of "feline" provides an example:
    /// 2 : resembling a cat: such as a : sleekly graceful b : sly, treacherous c : stealthy
    ///  
    /// The text "resembling a cat: such as " is the binding substitute for the senses that follow.
    /// </example>
    public class BindingSubstitute : Sense
    {
        /// <summary>
        /// Gets or sets the sense.
        /// </summary>
        public Sense Sense { get; set; }
    }
}