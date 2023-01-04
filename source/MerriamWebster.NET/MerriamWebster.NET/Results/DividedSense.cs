namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A <see cref="Sense"/> may be divided into two parts to show a particular relationship between two closely related meanings.
    /// The second part of the sense is contained in a <see cref="DividedSense"/>, consisting of a <see cref="SenseDivider"/> along with a second <see cref="SenseBase.DefiningTexts"/> collection.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// The divided sense should be inline with the preceding sense text.
    /// The sense divider is displayed in italics, preceded by a semicolon and space, and followed by a space.
    /// </remarks>
    public class DividedSense : SenseBase
    {
        /// <summary>
        /// Gets or sets the sense divider (eg. 'also', 'especially')
        /// </summary>
        public string SenseDivider { get; set; }
    }
}