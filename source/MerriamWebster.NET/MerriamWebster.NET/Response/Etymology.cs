namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// An etymology is an explanation of the historical origin of a word.
    /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense
    /// </summary>
    public struct Etymology
    {
        /// <summary>
        /// Possible values: "text" (required) or "et_snote"(optional)
        /// </summary>
        public string Type;
        /// <summary>
        /// For text: contains the etymology content <br/>
        /// For et_snote: contains a supplemental information note for the etymology (optional)
        /// </summary>
        public string[][] Content;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static implicit operator Etymology(string String) => new Etymology { Type = String };
        public static implicit operator Etymology(string[][] StringArrayArray) => new Etymology { Content = StringArrayArray };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}