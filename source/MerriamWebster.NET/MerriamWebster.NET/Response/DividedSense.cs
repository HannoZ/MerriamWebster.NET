using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A <see cref="Sense"/> may be divided into two parts to show a particular relationship between two closely related meanings.
    /// The second part of the sense is contained in a <see cref="DividedSense"/>, consisting of a <see cref="SenseDivider"/> along with a second <see cref="SenseBase.DefiningTexts"/>.
    /// </summary>
    public class DividedSense : SenseBase
    {
        /// <summary>
        /// Gets or sets the sense divider (eg. 'also', 'especially')
        /// </summary>
        [JsonProperty("sd")]
        public string SenseDivider { get; set; }
    }
}