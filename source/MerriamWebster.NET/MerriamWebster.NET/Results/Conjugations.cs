namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// All conjugations of a verb. Appears in the Spanish-English dictionary for most verbs. 
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// Typically displayed as a table, with rows organized by person/number, and each column containing data from a particular object in the conjugations class.
    /// </para>
    /// <para>
    /// The <see cref="Conjugation.Tense"/> identifies the tense; the tense name is typically displayed in bold as a column heading.
    /// The properties of the <see cref="Conjugation"/> populate the column, and are typically displayed in normal font.
    /// </para>
    /// </remarks>
    public class Conjugations
    {
        /// <summary>
        /// Creates a new instance of <see cref="Conjugations"/>.
        /// </summary>
        public Conjugations()
        {
            PresentParticiple = string.Empty;
            PastParticiple = string.Empty;
            Present = new Conjugation();
            IndefinitePast = new Conjugation();
            ImperfectPast = new Conjugation();
            Conditional = new Conjugation();
            Future = new Conjugation();
            Imperative = new Conjugation();
            PresentPerfect = new Conjugation();
            PastPerfect = new Conjugation();
            PreteritePerfect = new Conjugation();
            ConditionalPerfect = new Conjugation();
            FuturePerfect = new Conjugation();
            PresentSubjunctive = new Conjugation();
            ImperfectSubjunctive = new Conjugation();
            FutureSubjunctive = new Conjugation();
            PresentPerfectSubjunctive = new Conjugation();
            PastPerfectSubjunctive = new Conjugation();
            FuturePerfectSubjunctive = new Conjugation();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string PresentParticiple { get; set; }
        public string PastParticiple { get; set; }
        public Conjugation Present { get; set; }
        /// <remarks>
        /// Also called Preterit past
        /// </remarks>
        public Conjugation IndefinitePast { get; set; }
        public Conjugation ImperfectPast { get; set; }
        public Conjugation Conditional { get; set; }
        public Conjugation Future { get; set; }
        public Conjugation Imperative { get; set; }
        public Conjugation PresentPerfect { get; set; }
        /// <remarks>
        /// Also Pluperfect.
        /// </remarks>
        public Conjugation PastPerfect { get; set; }
        public Conjugation PreteritePerfect { get; set; }
        public Conjugation ConditionalPerfect { get; set; }
        public Conjugation FuturePerfect { get; set; }
        public Conjugation PresentSubjunctive { get; set; }
        public Conjugation ImperfectSubjunctive { get; set; }
        public Conjugation FutureSubjunctive { get; set; }
        public Conjugation PresentPerfectSubjunctive { get; set; }
        /// <remarks>
        /// Also called Pluperfect subjunctive
        /// </remarks>
        public Conjugation PastPerfectSubjunctive { get; set; }
        public Conjugation FuturePerfectSubjunctive { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}