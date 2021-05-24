﻿using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A word history paragraph provides historical background for a headword. 
    /// </summary>
    public class History
    {
        /// <summary>
        /// Heading to display at top of section.
        /// </summary>
        [JsonProperty("pl")]
        public string ParagraphLabel { get; set; }

        /// <summary>
        /// Gets or sets the paragraph text.
        /// </summary>
        [JsonProperty("pt")] 
        public string[][] ParagraphText { get; set; } = { };
    }
}