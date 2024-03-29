﻿using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    ///  A base class for (un)defined run-ons with properties that occur on both classes
    /// </summary>
    public abstract class RunOn
    {
        /// <summary>
        /// <i>Optional.</i> Gets or sets pronunciations.
        /// </summary>
        public ICollection<Pronunciation>? Pronunciations { get; set; }
        
        /// <summary>
        /// <i>Optional.</i>  Gets or sets the parenthesized subject/status label.
        /// </summary>
        public ParenthesizedSubjectStatusLabel? ParenthesizedSubjectStatusLabel { get; set; }

        /// <summary>
        /// <i>Optional.</i>  Gets or sets the general labels.
        /// </summary>
        public ICollection<GeneralLabel>? GeneralLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the subject/status labels.
        /// </summary>
        public ICollection<SubjectStatusLabel>? SubjectStatusLabels { get; set; }

        /// <summary>
        /// <i>Optional.</i>  Gets or sets variants.
        /// </summary>
        public ICollection<Variant>? Variants { get; set; }
        
        /// <summary>
        /// <i>Required for Undefined run-ons. For Defined run-ons: Spanish-English only. </i>
        /// <br/> Gets or sets the functional label.
        /// </summary>
        public FunctionalLabel? FunctionalLabel { get; set; }

    }
}