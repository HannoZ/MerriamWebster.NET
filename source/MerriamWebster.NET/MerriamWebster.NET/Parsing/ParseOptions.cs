namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Provides a few options that can be used to configure the way results are parsed.
    /// </summary>
    public class ParseOptions
    {
        /// <summary>
        /// Returns a <see cref="ParseOptions"/> instance with default settings.
        /// </summary>
        public static readonly ParseOptions Default = new ParseOptions();

        /// <summary>
        /// Creates a new instance of the <see cref="ParseOptions"/> class with specified settings.
        /// </summary>
        public ParseOptions(AudioFormat audioFormat, bool skipAdditionalStems, bool removeMarkup)
        {
            AudioFormat = audioFormat;
            SkipAdditionalStems = skipAdditionalStems;
            RemoveMarkup = removeMarkup;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ParseOptions"/> class with default settings.
        /// </summary>
        private ParseOptions()
        {
            AudioFormat = AudioFormat.Mp3;
            SkipAdditionalStems = true;
            RemoveMarkup = true;
        }

        /// <summary>
        /// Specifies the audio format for audio files. Default is mp3.
        /// </summary>
        public AudioFormat AudioFormat { get; set; }

        /// <summary>
        /// Gets or sets whether to skip parsing of additional stems.
        /// </summary>
        /// <remarks>
        /// In some cases a bunch of (mostly) unrelated entries can be returned as a list of additional stems. (eg. uña will return many entries related to 'una', casa will return many additional entries of combinations of case + another word)
        /// Set to <c>true</c> (this is the default), to have those entries filtered out. 
        /// </remarks>
        public bool SkipAdditionalStems { get; set; }
        /// <summary>
        /// Gets or sets whether to remove markup from translations.
        /// </summary>
        /// <remarks>
        /// Translations are often in a pre-formatted formatting, using some specific markup tokens  (eg. "{bc}an ion NH{inf}4{\/inf}{sup}+{\/sup} derived from {a_link|ammonia}").
        /// Set to <c>true</c> (this is the default) to remove the markup (raw value will still be returned as well).
        /// </remarks>
        public bool RemoveMarkup { get; set; }
    }
}
