using System;
using System.Collections.Generic;
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
        public static T? ParseSingle<T>(JsonElement source, string propName)
        where T : ILabel
        {
            var text = JsonParserHelper.GetStringValue(source, propName);
            if (string.IsNullOrEmpty(text))
            {
                return default;
            }

            var instance = Activator.CreateInstance(typeof(T), text);
            return instance is T t ? t : default;
        }
        
        /// <summary>
        /// Parses multiple label values. 
        /// </summary>
        /// <typeparam name="T">The label type</typeparam>
        /// <param name="source">The source data (must be a json array)</param>
        /// <param name="propName">The JSON property name</param>
        /// <returns>A collection of labels if values were found, else <c>null</c></returns>
        public static ICollection<T>? ParseMultiple<T>(JsonElement source, string propName)
          where T : ILabel
        {
            var labels = JsonParserHelper.GetStringValues(source, propName);
            if (labels == null)
            {
                return null;
            }

            var result = new List<T>();
            foreach (var label in labels)
            {
                var instance = Activator.CreateInstance(typeof(T), label);
                if (instance is T t)
                {
                    result.Add(t);
                }
            }

            return result;
        }
    }
}