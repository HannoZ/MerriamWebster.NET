using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Results.Medical
{
    public class MedicalEntry : EntryBase
    {
        public MedicalEntry() : base()
        {
            
        }

        /// <summary>
        /// <i>Optional.</i> Gets or sets biographical notes.
        /// </summary>
        public BiographicalNote BiographicalNote { get; internal set; }
    }
}