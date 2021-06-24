﻿namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The <see cref="Example"/> class.
    /// </summary>
    /// <remarks>
    /// In the Spanish-English dictionary, examples are short sentences that illustrate the use of the headword.<br/>
    /// For other dictionaries, so called 'variants' or other text that further illustrates the definition are returned as example.
    /// In that case the <see cref="Translation"/> property will always be null.
    /// Sometimes a <see cref="Quote"/> may also be present if the text was cited from some source.
    /// </remarks>
    public class Example
    {
        /// <summary>
        /// Gets or sets the raw sentence, ie. the text as it is returned from the API.
        /// </summary>
        public string RawSentence { get; set; }
        /// <summary>
        /// Gets or sets the parsed sentence (depending on parse options).
        /// </summary>
        /// <remarks>By default the markup is removed from the text.</remarks>
        public string Sentence { get; set; }
        /// <summary>
        /// Gets or sets the sentence where MW markup is replaced by HTML markup.
        /// </summary>
        public string HtmlSentence { get; set; }
        /// <summary>
        /// Gets or sets the translation.
        /// </summary>
        /// <remarks>Spanish-English only.</remarks>
        public string Translation { get; set; }
        /// <summary>
        /// Gets or sets the quote information.
        /// </summary>
        public Quote Quote { get; set; }
    }
}