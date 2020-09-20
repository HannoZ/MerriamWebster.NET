namespace MerriamWebster.NET.Dto
{
    public class Conjugation
    {
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
