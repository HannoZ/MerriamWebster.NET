namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct DefiningTextComplexTypeWrapper
    {
        public DefiningTextComplexType[] DefiningTextComplexTypes;
        public RunInWrap RunInWrap;
        public string TypeLabelOrText;

        public static implicit operator DefiningTextComplexTypeWrapper(DefiningTextComplexType[] arr) => new DefiningTextComplexTypeWrapper { DefiningTextComplexTypes = arr };
        public static implicit operator DefiningTextComplexTypeWrapper(RunInWrap runInWrap) => new DefiningTextComplexTypeWrapper { RunInWrap = runInWrap };
        public static implicit operator DefiningTextComplexTypeWrapper(string s) => new DefiningTextComplexTypeWrapper { TypeLabelOrText = s };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}