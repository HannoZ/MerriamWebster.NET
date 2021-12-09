using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// <i>Medical dictionary only.</i> A biographical note provides information on a historical or mythological figure relevant to the headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>Displayed in its own paragraph. May be preceded by a heading such as "Biographical Note for [headword]".</para>
    /// <para>A biodate or a bionw containing a biosname should be followed by a comma and space.</para>
    /// <para>A biodate should be preceded by a space.</para>
    /// <para>biopname, biosname, and biodate are typically displayed in bold, while biotx should be displayed in normal font.</para>
    /// </remarks>
    public class BiographicalNote
    {
        /// <summary>
        /// Gets the contents.
        /// </summary>
        public ICollection<IDefiningText> Contents { get;  } = new List<IDefiningText>();
    }
}