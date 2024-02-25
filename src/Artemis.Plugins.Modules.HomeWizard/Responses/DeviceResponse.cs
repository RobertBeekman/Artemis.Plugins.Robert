using System.Text.Json.Serialization;

namespace Artemis.Plugins.Modules.HomeWizard.Responses;

public class DeviceResponse
{
    [JsonPropertyName("product_name")]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("product_type")]
    public string ProductType { get; set; } = string.Empty;

    [JsonPropertyName("serial")]
    public string Serial { get; set; } = string.Empty;

    [JsonPropertyName("firmware_version")]
    public string FirmwareVersion { get; set; } = string.Empty;

    [JsonPropertyName("api_version")]
    public string ApiVersion { get; set; } = string.Empty;
}