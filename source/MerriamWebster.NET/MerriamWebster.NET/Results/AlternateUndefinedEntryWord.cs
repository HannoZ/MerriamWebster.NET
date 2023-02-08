namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// In bilingual dictionaries, an undefined entry word may have multiple forms according to grammatical gender and number. 
    /// In digital formats such forms are spelled out, while in space-constrained environments they may be presented in shortened cutback form.
    /// An alternate undefined entrycontains an undefined entry word cutback in <see cref="TextCutback"/> as well as a spelled-out undefined entry word in <see cref="Text"/>.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// The first <see cref="Text"/> is preceded by an em-dash.
    /// </para>
    /// <para>
    /// Both <see cref="TextCutback"/> and <see cref="Text"/> are displayed in bold.
    /// </para>
    /// <para>
    /// Separate a series of <see cref="UndefinedRunOn.EntryWord"/> and <see cref="AlternateUndefinedEntryWord"/> elements with a comma and space.
    /// </para>
    /// <para>
    /// Note: within an <see cref="AlternateUndefinedEntryWord"/> the <see cref="TextCutback"/> is simply a shortened form of the immediately following <see cref="Text"/>, so only one of these two elements should be presented to the user at a time.
    /// </para>
    /// </remarks>
    public class AlternateUndefinedEntryWord
    {
        /// <summary>
        /// Text of undefined entry word cutback form
        /// </summary>
        public string? TextCutback { get; set; }

        /// <summary>
        /// Text of undefined entry word spelled-out form
        /// </summary>
        public string Text { get; set; } = string.Empty;
    }
}