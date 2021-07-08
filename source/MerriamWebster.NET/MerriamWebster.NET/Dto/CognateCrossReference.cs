using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// When a headword is a less common spelling of another word with the same meaning, there will be a cognate cross-reference pointing to the headword with the more common spelling.
    /// </summary>
    public class CognateCrossReference
    {
        /// <summary>
        /// Cognate cross-reference label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the cross-reference targets.
        /// </summary>
        public ICollection<CrossReferenceTarget> CrossReferenceTargets { get; set; } = new List<CrossReferenceTarget>();
    }
}