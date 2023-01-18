namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class DefiningTextParserFactory
    {
        public static IDefiningTextParser Create(string type)
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