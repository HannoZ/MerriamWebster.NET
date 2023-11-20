using System.Collections.Generic;
using System.Text.Json;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class for parsing json elements.
    /// </summary>
    public static class JsonParserHelper
    {
        /// <summary>
        /// Gets the string value of a property, or <c>null</c> if the property does not exist
        /// </summary>
        public static string? GetStringValue(JsonElement element, string propName)
        {
            if (element.TryGetProperty(propName, out var value))
            {
                return value.GetString();
            }

            return null;
        }

        /// <summary>
        /// Gets the string values of a property, or <c>null</c> if the property does not exist or is not an array.
        /// </summary>
        public static IEnumerable<string>? GetStringValues(JsonElement element, string propName)
        {
            if (element.TryGetProperty(propName, out var valuesElement))
            {
                if (valuesElement.ValueKind != JsonValueKind.Array)
                {
                    return null;
                }

                var returnValue = new List<string>(valuesElement.GetArrayLength());
                var values = valuesElement.EnumerateArray();
                foreach (var value in values)
                {
                    var strVal = value.GetString();
                    if (strVal != null)
                    {
                        returnValue.Add(strVal);
                    }
                }

                return returnValue;
            }

            return null;
        }
    }
}