namespace MerriamWebster.NET.Response
{
    public struct DefiningTextComplexTypeWrapper
    {
        public DefiningTextComplexType[] DefiningTextComplexTypeArray;
        public string TypeOrLabel;

        public static implicit operator DefiningTextComplexTypeWrapper(DefiningTextComplexType[] arr) => new DefiningTextComplexTypeWrapper { DefiningTextComplexTypeArray = arr };
        public static implicit operator DefiningTextComplexTypeWrapper(string s) => new DefiningTextComplexTypeWrapper { TypeOrLabel = s };
    }
}