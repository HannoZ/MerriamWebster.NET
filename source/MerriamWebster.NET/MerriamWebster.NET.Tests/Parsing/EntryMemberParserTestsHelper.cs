using System.Text.Json;

namespace MerriamWebster.NET.Tests.Parsing
{
    public class EntryMemberParserTestsHelper
    {
        public static JsonProperty GetJsonProperty(string source, string propName)
        {
            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            var jsonProperty = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == propName)
                {
                    jsonProperty = prop;
                    break;
                }                
            }

            return jsonProperty;
        }
    }
}