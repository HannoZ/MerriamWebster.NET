namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct DefiningTextObjectWrapper
    {
        public DefiningTextObject[] DefiningTextArray;
        public CalledAlsoNote CalledAlso;
        public BiographicalNameWrap BiographicalNameWrap;


        /// <summary>
        /// The definition type, or definition text. 
        /// </summary>
        /// <remarks>
        /// The main definition starts with an array of two <see cref="DefiningTextObjectWrapper"/>s: one with <see cref="TypeOrText"/>: "text", followed by the actual definition text.
        /// Additional information is also an array of  two <see cref="DefiningTextObjectWrapper"/>s: one with the type (bnw, ca, ri, snote, uns, or vis), followed by a <see cref="DefiningText"/> object.
        /// In the Spanish-English dictionary, the <see cref="DefiningText"/> can contain translations. 
        /// </remarks>
        public string TypeOrText;

        public static implicit operator DefiningTextObjectWrapper(DefiningTextObject[] obj) => new DefiningTextObjectWrapper { DefiningTextArray = obj };
        public static implicit operator DefiningTextObjectWrapper(string s) => new DefiningTextObjectWrapper { TypeOrText = s };
        public static implicit operator DefiningTextObjectWrapper(CalledAlsoNote ca) => new DefiningTextObjectWrapper{CalledAlso = ca};
        public static implicit operator DefiningTextObjectWrapper(BiographicalNameWrap bnw) => new DefiningTextObjectWrapper { BiographicalNameWrap = bnw };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}