namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The cross-reference target. 
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    ///The <see cref="Target"/> is typically displayed in smallcaps. If <see cref="TargetId"/> is present,
    /// do not display but use in forming cross-reference hyperlink as described below.
    /// </para>
    /// <para>
    /// The <see cref="Label"/> is typically displayed in italics and should be followed by a space.
    /// </para>
    /// <para>
    /// A <see cref="SenseNumber"/> is typically displayed in normal font and should be preceded by a space.
    /// </para>
    /// </remarks>
    public class CrossReferenceTarget
    {
        /// <summary>
        /// Cognate cross-reference label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        ///  When present, use as cross-reference target ID for immediately preceding <see cref="Target"/>.
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        /// Provides hyperlink text in all cases, and cross-reference target ID when no immediately following <see cref="TargetId"/>.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Sense number of cross-reference target.
        /// </summary>
        public string SenseNumber { get; set; }

    }
}