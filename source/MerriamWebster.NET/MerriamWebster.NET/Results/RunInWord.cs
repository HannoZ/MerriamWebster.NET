using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A run-in entry word is a defined word that occurs in the running text of an entry.
    /// The run-in ri groups together one or more run-in entry words rie and any accompanying pronunciations or variants.
    /// Run-ins occur most frequently in geographical entries.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Inline in normal font, except for <see cref="RunInWrap.RunInEntryWord"/> which is typically displayed in bold.
    /// </remarks>
    public class RunIn : IDefiningText
    {
        /// <summary>
        /// Gets or sets the run-in wraps.
        /// </summary>
        /// <remarks>
        /// Each run-in wrap either contains a run-in entry word or intervening text.
        /// </remarks>
        public ICollection<RunInWrap> Wraps { get; set; } = [];
        
        /// <inheritdoc />
        [JsonIgnore]
        public FormattedText MainText
        {
            get
            {
                StringBuilder rawTexts = new StringBuilder();
                foreach (var runInWrap in Wraps)
                {
                    // Text is not actually a property of the RunInWrap, but that's easier to process
                    // so each runin wrap will only have either the RunInEntryWord or the Text property set
                    if (runInWrap.RunInEntryWord != null)
                    {
                        rawTexts.Append(runInWrap.RunInEntryWord.RawText);
                    }
                    if (runInWrap.Text != null)
                    {
                        rawTexts.Append(runInWrap.Text.RawText);
                    }
                }

                return rawTexts.ToString();
            }
        }
    }

    /// <summary>
    /// Run-in wrap object
    /// </summary>
    public class RunInWrap
    {
        /// <summary>
        /// Gets or sets the  run-in entry word.
        /// </summary>
        public FormattedText? RunInEntryWord { get; set; }

        /// <summary>
        /// Gets or sets intervening text.
        /// </summary>
        public FormattedText? Text { get; set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation>? Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets variants.
        /// </summary>
        public ICollection<Variant>? Variants { get; set; }
    }
}