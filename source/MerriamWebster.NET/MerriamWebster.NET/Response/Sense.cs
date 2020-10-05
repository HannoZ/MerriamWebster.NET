using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The sense gathers together all content relevant to a particular meaning of a headword or defined run-on phrase.
    /// </summary>
    /// <remarks>
    /// The <see cref="Sense"/> is a key organizational unit of the <see cref="DictionaryEntry"/>, and gathers together all content relevant to a particular meaning of a headword.
    /// Senses are presented in a numbered series, with further divisions into subsenses identified by lowercase letters and parenthesized numbers.
    /// <see cref="SenseSequence"/>s are organized by part of speech for verb entries: if a verb can be both transitive and intransitive, there will be two verb dividers, one marking the sense sequence for the transitive verb and the other the sense sequence for the intransitive verb.
    /// <br/><br/>
    /// The main definition section <see cref="Definition"/> encompasses all of the <see cref="SenseSequence"/>s and verb dividers <i>vd</i> for a headword.
    /// A <see cref="SenseSequence"/>s groups together the numbered senses (<i>sense</i> and <i>sen</i>) defining particular meanings of the headword.
    /// Finally, more complex sense structures are represented by <i>pseq</i>, <i>sdsense</i>, and <i>bs</i>.
    /// </remarks>
    public class Sense
    {
        /// <summary>
        /// The sense number identifies a sense or subsense within the entry.
        /// A <see cref="SenseNumber"/> may contain bold Arabic numerals, bold lowercase letters, or parenthesized Arabic numerals.
        /// </summary>
        [JsonProperty("sn", NullValueHandling = NullValueHandling.Ignore)]
        public string SenseNumber { get; set; }

        /// <summary>
        /// This label notes whether a particular sense of a verb is transitive (T) or intransitive (I).<br/>
        /// The sense-specific grammatical label is contained in an <see cref="SenseSpecificGrammaticalLabel"/>.
        /// </summary>
        [JsonProperty("sgram")]
        public string SenseSpecificGrammaticalLabel { get; set; }

        [JsonProperty("dt")] 
        public DefiningTextObjectWrapper[][] DefiningTexts { get; set; } = { };
        
        [JsonProperty("sdsense", NullValueHandling = NullValueHandling.Ignore)]
        public DividedSense DividedSense { get; set; }

        /// <summary>
        /// An etymology is an explanation of the historical origin of a word.
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Etymologies { get; set; } = { };

        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = { };

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = { };
        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = { };

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };

        /// <summary>
        /// A thesaurus entry typically contains a list of synonyms for the headword.
        /// </summary>
        [JsonProperty("syn_list")]
        public MwList[][] Synonyms { get; set; } = { };

        /// <summary>
        /// A thesaurus <see cref="DictionaryEntry"/> may contain a list of words related to the headword. A related word list is contained in <see cref="RelatedWords"/>.
        /// </summary>
        [JsonProperty("rel_list")] 
        public MwList[][] RelatedWords { get; set; } = { };

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = { };
    }
}