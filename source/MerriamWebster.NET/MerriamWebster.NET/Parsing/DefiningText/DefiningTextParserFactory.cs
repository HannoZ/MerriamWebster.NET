namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Factory for creating <see cref="IDefiningTextParser"/> instances.
    /// </summary>
    public class DefiningTextParserFactory
    {
        /// <summary>
        /// Creates a <see cref="IDefiningTextParser"/> instance based on the specified type.
        /// </summary>
        /// <param name="type">The defining text type. All known types are defined in the <see cref="DefiningTextTypes"/> class.</param>
        /// <returns>The implementation for the specified <paramref name="type"/>, or <c>null</c> for an unknown type.</returns>
        public static IDefiningTextParser? Create(string? type)
        {
            return type switch
            {
                DefiningTextTypes.Text => new TextDefiningTextParser(),
                DefiningTextTypes.VerbalIllustration => new VisDefiningTextParser(),
                DefiningTextTypes.BiographicalNameWrap => new BiographicalNameWrapDefiningTextParser(),
                DefiningTextTypes.CalledAlsoNote => new CalledAlsoNoteDefiningTextParser(),
                DefiningTextTypes.RunIn => new RunInDefiningTextParser(),
                DefiningTextTypes.SupplementalNote => new SupplementalNoteDefiningTextParser(),
                DefiningTextTypes.UsageNote => new UsageNoteDefiningTextParser(),

                // Spanish-English only
                DefiningTextTypes.GenderLabel => new GenderLabelDefiningTextParser(),
                DefiningTextTypes.GenderForms => new GenderFormsDefiningTextParser(),

                _ => null
            };
        }
    }
}