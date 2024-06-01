using System.Collections.Generic;
using System.Text.Json.Serialization;
using MerriamWebster.NET.Parsing.DefiningText;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Contains properties that both exist on <see cref="Sense"/> and <see cref="DividedSense"/>.
    /// </summary>
    public class SenseBase : SenseSequenceSense
    {
        /// <summary>
        /// Gets or sets the defining texts.
        /// </summary>
        public ICollection<IDefiningText> DefiningTexts { get; set; } = [];

        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation>? Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the variants.
        /// </summary>
        public ICollection<Variant>? Variants { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection>? Inflections { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the general labels.
        /// </summary>
        public ICollection<GeneralLabel>? GeneralLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the subject/status labels.
        /// </summary>
        public ICollection<SubjectStatusLabel>? SubjectStatusLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the sense specific grammatical label
        /// </summary>
        public SenseSpecificGrammaticalLabel? SenseSpecificGrammaticalLabel { get; set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology.
        /// </summary>
        public Etymology? Etymology { get; set; }

        /// <summary>
        /// Experimental feature! A summary of the <see cref="DefiningTexts"/> content.
        /// </summary>
        [JsonIgnore]
        public FormattedText Summary => DefiningTexts.Build();
    }
}