using System.Collections.Generic;
using System.Text.Json.Serialization;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Modules.HomeWizard.Responses;

public class P1DataResponse
{
    [JsonPropertyName("wifi_ssid")]
    [DataModelProperty(Name = "WiFi SSID", Description = "The WiFi network name")]
    public string WifiSsid { get; set; } = string.Empty;

    [JsonPropertyName("wifi_strength")]
    [DataModelProperty(Name = "WiFi Strength", Description = "The WiFi signal strength")]
    public int WifiStrength { get; set; }

    [JsonPropertyName("smr_version")]
    [DataModelProperty(Name = "SMR Version", Description = "The SMR version")]
    public int SmrVersion { get; set; }

    [JsonPropertyName("meter_model")]
    [DataModelProperty(Name = "Meter Model", Description = "The meter model")]
    public string MeterModel { get; set; } = string.Empty;

    [JsonPropertyName("unique_id")]
    [DataModelProperty(Name = "Unique ID", Description = "The unique identifier of the meter")]
    public string UniqueId { get; set; } = string.Empty;

    [JsonPropertyName("active_tariff")]
    [DataModelProperty(Name = "Active Tariff", Description = "The active tariff")]
    public int ActiveTariff { get; set; }

    [JsonPropertyName("total_power_import_kwh")]
    [DataModelProperty(Name = "Total Power Import", Affix = "kWh", Description = "The total power import in kWh")]
    public double TotalPowerImportKwh { get; set; }

    [JsonPropertyName("total_power_import_t1_kwh")]
    [DataModelProperty(Name = "Total Power Import T1", Affix = "kWh", Description = "The power usage meter reading for tariff 1 in kWh")]
    public double TotalPowerImportT1Kwh { get; set; }

    [JsonPropertyName("total_power_import_t2_kwh")]
    [DataModelProperty(Name = "Total Power Import T2", Affix = "kWh", Description = "The power usage meter reading for tariff 2 in kWh")]
    public double TotalPowerImportT2Kwh { get; set; }

    [JsonPropertyName("total_power_export_kwh")]
    [DataModelProperty(Name = "Total Power Export", Affix = "kWh", Description = "The total power export in kWh")]
    public double TotalPowerExportKwh { get; set; }

    [JsonPropertyName("total_power_export_t1_kwh")]
    [DataModelProperty(Name = "Total Power Export T1", Affix = "kWh", Description = "The power feed-in meter reading for tariff 1 in kWh")]
    public double TotalPowerExportT1Kwh { get; set; }

    [JsonPropertyName("total_power_export_t2_kwh")]
    [DataModelProperty(Name = "Total Power Export T2", Affix = "kWh", Description = "The power feed-in meter reading for tariff 2 in kWh")]
    public double TotalPowerExportT2Kwh { get; set; }

    [JsonPropertyName("active_power_w")]
    [DataModelProperty(Name = "Active Power", Affix = "W", Description = "The total active usage in watt")]
    public double ActivePowerW { get; set; }

    [JsonPropertyName("active_power_l1_w")]
    [DataModelProperty(Name = "Active Power L1", Affix = "W", Description = "The active usage for phase 1 in watt")]
    public double ActivePowerL1W { get; set; }

    [JsonPropertyName("active_power_l2_w")]
    [DataModelProperty(Name = "Active Power L2", Affix = "W", Description = "The active usage for phase 2 in watt")]
    public double ActivePowerL2W { get; set; }

    [JsonPropertyName("active_power_l3_w")]
    [DataModelProperty(Name = "Active Power L3", Affix = "W", Description = "The active usage for phase 3 in watt")]
    public double ActivePowerL3W { get; set; }

    [JsonPropertyName("active_voltage_l1_v")]
    [DataModelProperty(Name = "Active Voltage L1", Affix = "V", Description = "The active voltage for phase 1 in volt")]
    public double ActiveVoltageL1V { get; set; }

    [JsonPropertyName("active_voltage_l2_v")]
    [DataModelProperty(Name = "Active Voltage L2", Affix = "V", Description = "The active voltage for phase 2 in volt")]
    public double ActiveVoltageL2V { get; set; }

    [JsonPropertyName("active_voltage_l3_v")]
    [DataModelProperty(Name = "Active Voltage L3", Affix = "V", Description = "The active voltage for phase 3 in volt")]
    public double ActiveVoltageL3V { get; set; }

    [JsonPropertyName("active_current_a")]
    [DataModelProperty(Name = "Active Current", Affix = "A", Description = "The total active current in ampere")]
    public double ActiveCurrentA { get; set; }

    [JsonPropertyName("active_current_l1_a")]
    [DataModelProperty(Name = "Active Current L1", Affix = "A", Description = "The active current for phase 1 in ampere")]
    public double ActiveCurrentL1A { get; set; }

    [JsonPropertyName("active_current_l2_a")]
    [DataModelProperty(Name = "Active Current L2", Affix = "A", Description = "The active current for phase 2 in ampere")]
    public double ActiveCurrentL2A { get; set; }

    [JsonPropertyName("active_current_l3_a")]
    [DataModelProperty(Name = "Active Current L3", Affix = "A", Description = "The active current for phase 3 in ampere")]
    public double ActiveCurrentL3A { get; set; }

    [JsonPropertyName("voltage_sag_l1_count")]
    [DataModelProperty(Name = "Voltage Sag L1 Count", Description = "Number of voltage sags detected by the meter for phase 1")]
    public double VoltageSagL1Count { get; set; }

    [JsonPropertyName("voltage_sag_l2_count")]
    [DataModelProperty(Name = "Voltage Sag L2 Count", Description = "Number of voltage sags detected by the meter for phase 2")]
    public double VoltageSagL2Count { get; set; }

    [JsonPropertyName("voltage_sag_l3_count")]
    [DataModelProperty(Name = "Voltage Sag L3 Count", Description = "Number of voltage sags detected by the meter for phase 3")]
    public double VoltageSagL3Count { get; set; }

    [JsonPropertyName("voltage_swell_l1_count")]
    [DataModelProperty(Name = "Voltage Swell L1 Count", Description = "Number of voltage swells detected by the meter for phase 1")]
    public double VoltageSwellL1Count { get; set; }

    [JsonPropertyName("voltage_swell_l2_count")]
    [DataModelProperty(Name = "Voltage Swell L2 Count", Description = "Number of voltage swells detected by the meter for phase 2")]
    public double VoltageSwellL2Count { get; set; }

    [JsonPropertyName("voltage_swell_l3_count")]
    [DataModelProperty(Name = "Voltage Swell L3 Count", Description = "Number of voltage swells detected by the meter for phase 3")]
    public double VoltageSwellL3Count { get; set; }

    [JsonPropertyName("any_power_fail_count")]
    [DataModelProperty(Name = "Any Power Fail Count", Description = "Number of power failures detected by the meter")]
    public double AnyPowerFailCount { get; set; }

    [JsonPropertyName("long_power_fail_count")]
    [DataModelProperty(Name = "Long Power Fail Count", Description = "Number of 'long' power fails detected by the meter")]
    public double LongPowerFailCount { get; set; }

    [JsonPropertyName("total_gas_m3")]
    [DataModelProperty(Name = "Total Gas", Affix = "m3", Description = "The gas meter reading in m3 for the first detected gas meter")]
    public double TotalGasM3 { get; set; }

    [JsonPropertyName("gas_timestamp")]
    [DataModelProperty(Name = "Gas Timestamp", Description = "The most recent gas update timestamp as numeric value")]
    public long GasTimestamp { get; set; }

    [JsonPropertyName("gas_unique_id")]
    [DataModelProperty(Name = "Gas Unique ID", Description = "The unique identifier of the gas meter")]
    public string GasUniqueId { get; set; } = string.Empty;

    [JsonPropertyName("external")]
    [DataModelProperty(Name = "External Meters", Description = "Array of external meter readings")]
    public List<ExternalMeter> External { get; set; } = [];
}