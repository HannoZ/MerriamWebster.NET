using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A called-also note lists other names a headword is called in a given sense.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// A called-also note is preceded by an em-dash and a space.
    /// </para>
    /// <para>
    /// The <see cref="Intro"/> is typically displayed in normal font, and the <see cref="CalledAlsoTarget.TargetText"/> in italics.
    /// </para>
    /// <para>
    /// The <see cref="CalledAlsoTarget.ParenthesizedNumber"/> is displayed in parentheses, followed by a space.
    /// </para>
    /// <para>
    /// Note that a called-also note is typically found at an entry providing detailed definition content, and hence a hyperlink is not generated for the <see cref="CalledAlsoTarget.TargetText"/>.
    /// If the <see cref="CalledAlsoTarget.TargetText"/> is entered separately in the dictionary, that entry will typically have a cross-reference back to the detailed entry where the called-also note occurs.
    /// </para>
    /// <para>
    /// Note, however, that where a <see cref="CalledAlsoTarget.Reference"/> is present, it may be used to generate a hyperlink if desired.
    /// </para>
    /// </remarks>
    public class CalledAlsoNote : IDefiningText
    {
        /// <summary>
        /// contains introductory text "called also"
        /// </summary>
        public string Intro { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the called-also targets.
        /// </summary>
        public ICollection<CalledAlsoTarget> Targets { get; set; } = new List<CalledAlsoTarget>();


        /// <inheritdoc />
        [JsonIgnore]
        public FormattedText MainText
        {
            get
            {
                return Intro + ": " + string.Join(',', Targets.Select(t => t.ToString()));
            }
        }
    }
}