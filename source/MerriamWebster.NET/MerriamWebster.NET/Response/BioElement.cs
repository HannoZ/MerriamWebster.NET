namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// See <see cref="BiographicalNote"/>.
    /// </summary>
    public struct BioElement
    {
        public BiographicalNote BiographicalNote;
        public string Type;

        public static implicit operator BioElement(BiographicalNote biographicalNote) => new BioElement { BiographicalNote = biographicalNote };
        public static implicit operator BioElement(string String) => new BioElement { Type = String };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}