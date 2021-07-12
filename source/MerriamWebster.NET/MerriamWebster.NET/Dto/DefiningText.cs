using System;
using MerriamWebster.NET.Dto;
using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <inheritdoc cref="IDefiningText"/>
    public class DefiningText : IDefiningText
    {
        public DefiningText(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// The definition content
        /// </summary>
        public FormattedText Text { get; set; } 
    }

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
        public string Intro { get; set; }
        /// <summary>
        /// Gets or sets the called-also targets.
        /// </summary>
        public ICollection<CalledAlsoTarget> Targets { get; set; } = new List<CalledAlsoTarget>();
    }

    /// <summary>
    /// The defining text is the text of the definition or translation for a particular sense.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The defining text is a collection that usually starts with a "text" object (<see cref="DefiningText"/> that contains the main definition.
    /// There are a number of other types that together form the entire definition. 
    /// </para>
    /// <para>
    /// <b>Display Guidance:</b>
    /// Inline in normal font
    /// </para>
    /// </remarks>
    public interface IDefiningText
    {

    }

    /// <summary>
    /// <i>Optional, Spanish-English only</i> In a bilingual dictionary, a gender label provides the grammatical gender for the immediately preceding translation of the headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically displayed in italics.
    /// </remarks>
    public class GenderLabel : IDefiningText
    {
        public GenderLabel(string label)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public Label Label { get; set; }
    }


}