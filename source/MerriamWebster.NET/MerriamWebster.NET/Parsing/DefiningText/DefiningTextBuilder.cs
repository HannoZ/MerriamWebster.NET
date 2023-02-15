using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Helper class to create a string from a collection of <see cref="IDefiningText"/>
    /// </summary>
    public static class DefiningTextBuilder
    {
        /// <summary>
        /// Takes a collection of <see cref="IDefiningText"/> and returns the contents as a single string. 
        /// </summary>
        /// <remarks>
        /// Note: this is an experimental feature
        /// </remarks>
        public static FormattedText Build(this ICollection<IDefiningText> definingTexts)
        {
            if (definingTexts == null || !definingTexts.Any())
            {
                return string.Empty;
            }

            var stringbuilder = new StringBuilder();
            foreach (var definingText in definingTexts)
            {
                stringbuilder.Append(" " + GetText(definingText).RawText);
            }

            return stringbuilder.ToString().Trim();
        }

        private static FormattedText GetText(IDefiningText dt)
        {
            // we don't want examples in the main text
            if (dt is VerbalIllustration)
            {
                return $"({dt.MainText})";
            }

            return dt.MainText;
        }
    }
}
