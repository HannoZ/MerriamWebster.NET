namespace MerriamWebster.NET.Dto
{
    public class CalledAlsoTarget
    {
        /// <summary>
        /// called-also target text
        /// </summary>
        public string TargetText { get; set; }
        /// <summary>
        /// called-also reference containing target ID
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// parenthesized number
        /// </summary>
        public string ParenthesizedNumber { get; set; }

        // todo  prs, psl
    }
}