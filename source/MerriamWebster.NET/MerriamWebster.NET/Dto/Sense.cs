using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    public class Sense
    {
        /// <summary>
        /// The translation as it comes from the source.
        /// </summary>
        public string RawTranslation { get; set; }
        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted translation. The <see cref="RawTranslation"/> still contains the unformmated text. 
        /// </summary>
        public string Translation { get; set; }
        public ICollection<Example> Examples { get; set; } = new List<Example>();
        public IEnumerable<string> Synonyms { get; set; } = new List<string>(); 
    }
}