namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// All conjugations of a verb. Appears in the Spanish-English dictionary for most verbs. 
    /// </summary>
    public class Conjugations
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string PresentParticiple { get; set; }
        public string PastParticiple { get; set; }
        public Conjugation Present { get; set; }
        /// <remarks>
        /// Also Preterit past
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
        /// Also Pluperfect subjunctive
        /// </remarks>
        public Conjugation PastPerfectSubjunctive { get; set; } 
        public Conjugation FuturePerfectSubjunctive { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}