using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class for parsing labels. 
    /// </summary>
    public class LabelsParser
    {
        /// <summary>
        /// Parses a single label value. 
        /// </summary>
        /// <typeparam name="T">The label type</typeparam>
        /// <param name="source">The source data (must be a json object)</param>
        /// <param name="propName">The JSON property name</param>
        /// <returns>A new label instance if the property exists with non-empty value, else <c>null</c></returns>
        public static T ParseSingle<T>(JsonElement source, string propName)
        where T : ILabel
        {
            var text = JsonParserHelper.GetStringValue(source, propName);
            return string.IsNullOrEmpty(text) ? default : (T)Activator.CreateInstance(typeof(T), text);
        }
        
        /// <summary>
        /// Parses multiple label values. 
        /// </summary>
        /// <typeparam name="T">The label type</typeparam>
        /// <param name="source">The source data (must be a json array)</param>
        /// <param name="propName">The JSON property name</param>
        /// <returns>A collection of labels if values were found, else <c>null</c></returns>
        public static ICollection<T> ParseMultiple<T>(JsonElement source, string propName)
        where T : ILabel
        {
            var labels = JsonParserHelper.GetStringValues(source, propName);
            return labels != null
                ? new List<T>(labels.Select(label => (T)Activator.CreateInstance(typeof(T), label)))
                : null;
        }
    }
}