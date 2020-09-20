namespace MerriamWebster.NET.Dto
{
    public class Conjugations
    {
        public string PresentParticiple { get; set; }
        public string PastParticiple { get; set; }
        public Conjugation Present { get; set; }
        /// <summary>
        /// Also Preterit past
        /// </summary>
        public Conjugation IndefinitePast { get; set; }
        public Conjugation ImperfectPast { get; set; }
        public Conjugation Conditional { get; set; }
        public Conjugation Future { get; set; }
        public Conjugation Imperative { get; set; }
        public Conjugation PresentPerfect { get; set; }
        /// <summary>
        /// Also Pluperfect.
        /// </summary>
        public Conjugation PastPerfect { get; set; }
        public Conjugation PreteritePerfect { get; set; }
        public Conjugation ConditionalPerfect { get; set; }
        public Conjugation FuturePerfect { get; set; }
        public Conjugation PresentSubjunctive { get; set; }
        public Conjugation ImperfectSubjunctive { get; set; }
        public Conjugation FutureSubjunctive { get; set; }
        public Conjugation PresentPerfectSubjunctive { get; set; }
        /// <summary>
        /// Also Pluperfect subjunctive
        /// </summary>
        public Conjugation PastPerfectSubjunctive { get; set; } 
        public Conjugation FuturePerfectSubjunctive { get; set; }
    }
}