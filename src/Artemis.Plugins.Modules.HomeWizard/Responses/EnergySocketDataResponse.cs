using System.Text.Json.Serialization;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Modules.HomeWizard.Responses;

public class EnergySocketDataResponse
{
    [JsonPropertyName("wifi_ssid")]
    [DataModelProperty(Name = "WiFi SSID", Description = "The WiFi network name")]
    public string WifiSsid { get; set; } = string.Empty;

    [JsonPropertyName("wifi_strength")]
    [DataModelProperty(Name = "WiFi Strength", Description = "The WiFi signal strength")]
    public int WifiStrength { get; set; }

    [JsonPropertyName("total_power_import_kwh")]
    [DataModelProperty(Name = "Total Power Import", Affix = "kWh", Description = "The total power import in kWh")]
    public double TotalPowerImportKwh { get; set; }

    [JsonPropertyName("total_power_import_t1_kwh")]
    [DataModelProperty(Name = "Total Power Import T1", Affix = "kWh", Description = "The power usage meter reading for tariff 1 in kWh")]
    public double TotalPowerImportT1Kwh { get; set; }

    [JsonPropertyName("total_power_export_kwh")]
    [DataModelProperty(Name = "Total Power Export", Affix = "kWh", Description = "The total power export in kWh")]
    public double TotalPowerExportKwh { get; set; }

    [JsonPropertyName("total_power_export_t1_kwh")]
    [DataModelProperty(Name = "Total Power Export T1", Affix = "kWh", Description = "The power feed-in meter reading for tariff 1 in kWh")]
    public double TotalPowerExportT1Kwh { get; set; }

    [JsonPropertyName("active_power_w")]
    [DataModelProperty(Name = "Active Power", Affix = "W", Description = "The total active usage in watt")]
    public double ActivePowerW { get; set; }

    [JsonPropertyName("active_power_l1_w")]
    [DataModelProperty(Name = "Active Power L1", Affix = "W", Description = "The active usage for phase 1 in watt")]
    public double ActivePowerL1W { get; set; }

    [JsonPropertyName("active_voltage_v")]
    [DataModelProperty(Name = "Active Voltage", Affix = "V", Description = "The active voltage in volt")]
    public double ActiveVoltageV { get; set; }

    [JsonPropertyName("active_current_a")]
    [DataModelProperty(Name = "Active Current", Affix = "A", Description = "The active current in ampere")]
    public double ActiveCurrentA { get; set; }

    [JsonPropertyName("active_frequency_hz")]
    [DataModelProperty(Name = "Active Frequency", Affix = "Hz", Description = "The active frequency in hertz")]
    public double ActiveFrequencyHz { get; set; }
}