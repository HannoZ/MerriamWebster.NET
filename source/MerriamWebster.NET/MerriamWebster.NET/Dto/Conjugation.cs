namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A supplemental verb conjugation section is included in some bilingual dictionary entries. 
    /// </summary>
    public class Conjugation
    {
        /// <summary>
        /// Gets or sets the verb tense
        /// </summary>
        public string Tense { get; set; }
        /// <summary>
        /// Singular, first person.
        /// </summary>
        public string SgFirst { get; set; }
        /// <summary>
        /// Singular, second person.
        /// </summary>
        public string SgSecond { get; set; }
        /// <summary>
        /// Singular, third person.
        /// </summary>
        public string SgThird { get; set; }
        /// <summary>
        /// Plural, first person.
        /// </summary>
        public string PlFirst { get; set; }
        /// <summary>
        /// Plural, second person.
        /// </summary>
        public string PlSecond { get; set; }
        /// <summary>
        /// Plural, third person.
        /// </summary>
        public string PlThird { get; set; }
    }
}
