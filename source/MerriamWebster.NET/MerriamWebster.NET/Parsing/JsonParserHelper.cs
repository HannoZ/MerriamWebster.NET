using System.Collections.Generic;
using System.Text.Json;

namespace MerriamWebster.NET.Parsing
{
    public static class JsonParserHelper
    {
        public static string GetStringValue(JsonElement element, string propName)
        {
            if (element.TryGetProperty(propName, out var value))
            {
                return value.GetString();
            }

            return null;
        }

        public static IEnumerable<string> GetStringValues(JsonElement element, string propName)
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
                    returnValue.Add(value.GetString());
                }

                return returnValue;
            }

            return null;
        }
    }
}