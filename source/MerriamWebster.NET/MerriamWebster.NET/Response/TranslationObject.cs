using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Response
{
    public struct TranslationObject
    {
        public TranslationClass[] TranslationClassArray;
        public string String;

        public static implicit operator TranslationObject(TranslationClass[] transObj) => new TranslationObject { TranslationClassArray = transObj };
        public static implicit operator TranslationObject(string s) => new TranslationObject { String = s };
    }
}