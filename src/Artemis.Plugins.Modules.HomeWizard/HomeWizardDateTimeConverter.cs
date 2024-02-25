using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Artemis.Plugins.Modules.HomeWizard;

public class HomeWizardDateTimeConverter : JsonConverter<DateTime>
{
    private const string FORMAT = "yyMMddHHmmss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && DateTime.TryParseExact(reader.GetInt64().ToString(), FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }

        throw new JsonException($"Unable to parse the provided DateTime with the format {FORMAT}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(FORMAT, CultureInfo.InvariantCulture));
    }
}