﻿using System.Collections.Generic;
using System.Text;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// <i>Medical dictionary only.</i> A biographical note provides information on a historical or mythological figure relevant to the headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>Displayed in its own paragraph. May be preceded by a heading such as "Biographical Note for [headword]".</para>
    /// <para>A biodate or a bionw containing a biosname should be followed by a comma and space.</para>
    /// <para>A biodate should be preceded by a space.</para>
    /// <para>biopname, biosname, and biodate are typically displayed in bold, while biotx should be displayed in normal font.</para>
    /// </remarks>
    public class BiographicalNote
    {
        /// <summary>
        /// Gets the contents.
        /// </summary>
        public ICollection<IDefiningText> Contents { get;  } = new List<IDefiningText>();

        public override string ToString()
        {
            if (!Contents.HasValue())
            {
                return base.ToString();
            }

            StringBuilder sb = new StringBuilder();
            foreach (var definingText in Contents)
            {
                if (definingText is BiographicalNameWrap bnw)
                {
                    if (!string.IsNullOrEmpty(bnw.AlternateName))
                    {
                        sb.Append(bnw.AlternateName + ", ");
                    }
                    else
                    {
                        sb.Append((bnw.FirstName + " " + bnw.Surname).Trim() + ", ");
                    }
                }
                else if (definingText is DefiningText dt)
                {
                    if (dt.Type == "biodate")
                    {
                        sb.Append(dt.MainText + " " );
                    }
                    else
                    {
                        sb.Append(dt.MainText);
                    }
                }
            }

            return MarkupManipulator.RemoveMarkupFromString(sb.ToString());
        }
    }
}