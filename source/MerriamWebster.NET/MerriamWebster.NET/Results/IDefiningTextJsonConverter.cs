using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MerriamWebster.NET.Results
{
    internal sealed class IDefiningTextJsonConverter : JsonConverter<IDefiningText>
    {
        private static readonly Dictionary<string, Type> TypeMap = CreateTypeMap();

        public override IDefiningText Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null!;
            }

            using var document = JsonDocument.ParseValue(ref reader);
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Expected JSON object for IDefiningText.");
            }

            if (!document.RootElement.TryGetProperty("$type", out var typeProperty))
            {
                throw new JsonException("Missing $type discriminator for IDefiningText.");
            }

            var typeName = typeProperty.GetString();
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new JsonException("Invalid $type discriminator for IDefiningText.");
            }

            var targetType = ResolveType(typeName);
            if (targetType == null)
            {
                throw new JsonException($"Unknown IDefiningText type discriminator '{typeName}'.");
            }

            var json = document.RootElement.GetRawText();
            var result = (IDefiningText)JsonSerializer.Deserialize(json, targetType, options)!;
            return result;
        }

        public override void Write(Utf8JsonWriter writer, IDefiningText value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            var runtimeType = value.GetType();
            var element = JsonSerializer.SerializeToElement(value, runtimeType, options);

            writer.WriteStartObject();
            writer.WriteString("$type", runtimeType.FullName);
            foreach (var property in element.EnumerateObject())
            {
                property.WriteTo(writer);
            }
            writer.WriteEndObject();
        }

        private static Dictionary<string, Type> CreateTypeMap()
        {
            var interfaceType = typeof(IDefiningText);
            var types = interfaceType.Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && interfaceType.IsAssignableFrom(type))
                .ToArray();

            var map = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            foreach (var type in types)
            {
                if (type.FullName != null)
                {
                    map[type.FullName] = type;
                }
            }

            foreach (var group in types.GroupBy(type => type.Name).Where(group => group.Count() == 1))
            {
                map[group.Key] = group.Single();
            }

            return map;
        }

        private static Type? ResolveType(string typeName)
        {
            if (TypeMap.TryGetValue(typeName, out var type))
            {
                return type;
            }

            return Type.GetType(typeName, false, true);
        }
    }
}
