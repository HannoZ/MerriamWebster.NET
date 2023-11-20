using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Parser for the defining text ("dt") json object.
    /// </summary>
    public class JsonDefiningTextParser
    {
        /// <summary>
        /// Parses the defining text ("dt") json object.
        /// </summary>
        public static IEnumerable<IDefiningText> Parse(JsonElement source)
        {
            if (!source.TryGetProperty("dt", out var dtElement))
            {
                yield break;
            }

            var dts = dtElement.EnumerateArray();
            foreach (var dt in dts)
            {
                var dtArr = dt.EnumerateArray().ToList();
                if (dtArr.Count != 2)
                {
                    continue;
                }

                var definitionType = dtArr[0].GetString();
                var dataElement = dtArr[1];

                var parser = DefiningTextParserFactory.Create(definitionType);
                if (parser == null)
                {
                    continue;
                }

                if (dataElement.ValueKind == JsonValueKind.Array
                    && definitionType != DefiningTextTypes.RunIn) 
                    // run-in must be parsed as complete array instead of single elements because the elements belong together
                {
                    // handle type like "vis" that contain an array of items 
                    foreach (var element in dataElement.EnumerateArray())
                    {
                        yield return parser.Parse(element);
                    }
                }
                else
                {
                    yield return parser.Parse(dataElement);
                }
            }
        }
    }
}