﻿using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// An undefined entry word is derived from or related to the headword, carries a functional label and possibly other information, but does not have any definitions.<br/>
    /// A set of <see cref="UndefinedRunOn"/>s can follow (or "run on" from) the entry's main def definition section, with each such run-on containing an <see cref="EntryWord"/>.
    /// </summary>
    public class UndefinedRunOn
    {
        /// <summary>
        /// Undefined entry word
        /// </summary>
        [JsonProperty("ure")]
        public string EntryWord { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("aure", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateUndefinedEntryWord AlternateEntry { get; set; }

        /// <summary>
        /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        [JsonProperty("psl")]
        public string ParenthesizedSubjectStatusLabel { get; set; }

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = { };

    }
}