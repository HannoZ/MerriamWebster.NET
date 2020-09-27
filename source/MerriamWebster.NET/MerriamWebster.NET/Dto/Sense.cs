using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    public class Sense
    {
        /// <summary>
        /// The text as it comes from the source.
        /// </summary>
        public string RawText { get; set; }
        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted text. The <see cref="RawText"/> still contains the unformmated text. 
        /// </summary>
        public string Text { get; set; }
        public ICollection<Example> Examples { get; set; } = new List<Example>();
        public IEnumerable<string> Synonyms { get; set; } = new List<string>(); 
    }
}