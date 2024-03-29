﻿namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A supplemental verb conjugation section is included in some bilingual dictionary entries. 
    /// </summary>
    public class Conjugation
    {
        /// <summary>
        /// Creates a new instance of <see cref="Conjugation"/>.
        /// </summary>
        public Conjugation()
        {
            Tense = string.Empty;   
            SgFirst = string.Empty;
            SgSecond= string.Empty;
            SgThird = string.Empty;
            PlFirst = string.Empty;
            PlSecond = string.Empty;
            PlThird = string.Empty;
        }

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
