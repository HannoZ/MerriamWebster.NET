using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// An explanation of the historical origin of a word.
    /// An etymology might supply, for instance, the French origin of a headword, then further give the Latin origin of that French word.
    /// Also called: word origin.
    /// </summary>
    /// <remarks>
    /// <para>
    /// While the etymology most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
    /// </para>
    /// <para>
    /// <b>Display Guidance:</b>
    /// Typically displayed inline within square brackets or in its own block with a heading such as "Word Origin".
    /// </para>
    /// <para>
    /// Etymology notes do not appear to ever have more than one item. So the note texts are summarized into a single property <see cref="Note"/> for easier use.
    /// </para>
    /// </remarks>
    public class Etymology
    {
        /// <summary>
        /// Contains the etymology content.
        /// </summary>
        public FormattedText Text { get; set; } = new();

        /// <summary>
        /// <i>Optional.</i> A summary of any notes.
        /// </summary>
        [JsonIgnore]
        public FormattedText? Note
        {
            get
            {
                if (Notes.HasValue() == false)
                {
                    return null;
                }

                return string.Join(',', Notes!.Where(n => n.Text != string.Empty).Select(n => n.Text.RawText));
            }
        }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology notes.
        /// </summary>
        public ICollection<EtymologyNote>? Notes { get; set; }
    }
}
