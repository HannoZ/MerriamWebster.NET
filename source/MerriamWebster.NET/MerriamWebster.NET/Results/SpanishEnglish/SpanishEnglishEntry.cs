using System.Collections.Generic;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Results.SpanishEnglish
{
    public class SpanishEnglishEntry : EntryBase
    {
        public SpanishEnglishEntry() : base()
        {
            
        }

        //public SpanishEnglishMetadata Metadata { get; internal set; } = new ();
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the cross-references.
        /// </summary>
        public ICollection<CrossReference> CrossReferences { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> A supplemental verb conjugation section is included in some bilingual dictionary entries.
        /// </summary>
        public Conjugations Conjugations { get; internal set; }
    }
}