using System.Text.Json.Serialization;

namespace Artemis.Plugins.Modules.HomeWizard.Responses;

public class ExternalMeter
{
    [JsonPropertyName("unique_id")]
    public string UniqueId { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;
}