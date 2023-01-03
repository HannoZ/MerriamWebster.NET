using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The sense gathers together all content relevant to a particular meaning of a headword or defined run-on phrase.
    /// </summary>
    /// <remarks>
    /// The <see cref="Sense"/> is a key organizational unit of the <see cref="MwDictionaryEntry"/>, and gathers together all content relevant to a particular meaning of a headword.
    /// Senses are presented in a numbered series, with further divisions into subsenses identified by lowercase letters and parenthesized numbers.
    /// <see cref="SenseSequence"/>s are organized by part of speech for verb entries: if a verb can be both transitive and intransitive, there will be two verb dividers, one marking the sense sequence for the transitive verb and the other the sense sequence for the intransitive verb.
    /// <br/><br/>
    /// The main definition section <see cref="Definition"/> encompasses all of the <see cref="SenseSequence"/>s and verb dividers <i>vd</i> for a headword.
    /// A <see cref="SenseSequence"/>s groups together the numbered senses (<i>sense</i> and <i>sen</i>) defining particular meanings of the headword.
    /// Finally, more complex sense structures are represented by <i>pseq</i>, <i>sdsense</i>, and <i>bs</i>.
    /// </remarks>
    public class Sense : SenseBase
    {
        /// <summary>
        /// The sense number identifies a sense or subsense within the entry.
        /// A <see cref="SenseNumber"/> may contain bold Arabic numerals, bold lowercase letters, or parenthesized Arabic numerals.
        /// </summary>
        [JsonProperty("sn", NullValueHandling = NullValueHandling.Ignore)]
        public string SenseNumber { get; set; }


        /// <summary>
        /// A thesaurus entry typically contains a list of synonyms for the headword.
        /// </summary>
        [JsonProperty("syn_list")]
        public MwList[][] Synonyms { get; set; } = System.Array.Empty<MwList[]>();

        /// <summary>
        /// A thesaurus <see cref="MwDictionaryEntry"/> may contain a list of words related to the headword. A related word list is contained in <see cref="RelatedWords"/>.
        /// </summary>
        [JsonProperty("rel_list")]
        public MwList[][] RelatedWords { get; set; } = System.Array.Empty<MwList[]>();


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        [JsonProperty("sdsense", NullValueHandling = NullValueHandling.Ignore)]
        public DividedSense DividedSense { get; set; }
        

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = System.Array.Empty<CrossReference[]>();



        [JsonProperty("sense", NullValueHandling = NullValueHandling.Ignore)]
        public Sense SubSense { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}