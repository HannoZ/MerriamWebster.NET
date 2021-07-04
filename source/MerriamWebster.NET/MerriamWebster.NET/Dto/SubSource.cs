﻿namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Contains further detail on quote source (eg, name of larger work in which an essay is found).
    /// </summary>
    public class SubSource
    {
        /// <summary>
        /// Source work for quote.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Publication date of quote.
        /// </summary>
        public string PublicationDate { get; set; }

    }
}