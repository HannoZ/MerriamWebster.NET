namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// In bilingual dictionaries, an inflection may have a fully spelled-out form as well as a shortened cutback form for use in space-constrained environments.
    /// An alternate inflection aif surrounds both the spelled-out and cutback forms.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Display <see cref="Inflection"/> and <see cref="Cutback"/> as described in the <see cref="Inflection"/> section.
    /// </remarks>
    public class AlternateInflection
    {
        /// <summary>
        /// an inflection ending (eg, Spanish "-as", English "-ing")
        /// </summary>
        public string? Cutback { get; set; }
        /// <summary>
        /// a fully spelled-out inflection
        /// </summary>
        public string? Inflection { get; set; }
    }
}