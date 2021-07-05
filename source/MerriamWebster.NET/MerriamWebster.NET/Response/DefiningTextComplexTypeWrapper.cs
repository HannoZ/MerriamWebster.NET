namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct DefiningTextComplexTypeWrapper
    {
        public DefiningTextComplexType[] DefiningTextComplexTypeArray;
        public string TypeOrLabel;

        public static implicit operator DefiningTextComplexTypeWrapper(DefiningTextComplexType[] arr) => new DefiningTextComplexTypeWrapper { DefiningTextComplexTypeArray = arr };
        public static implicit operator DefiningTextComplexTypeWrapper(string s) => new DefiningTextComplexTypeWrapper { TypeOrLabel = s };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}