using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Modules.HomeWizard.Responses;

public class EnergySocketDataResponse
{
    [JsonPropertyName("total_power_import_t1_kwh")]
    [DataModelProperty(Name = "Total Power Import T1", Affix = "kWh", Description = "The power usage meter reading for tariff 1 in kWh")]
    public double TotalPowerImportT1Kwh { get; set; }
    
    [JsonPropertyName("total_power_export_t1_kwh")]
    [DataModelProperty(Name = "Total Power Export T1", Affix = "kWh", Description = "The power feed-in meter reading for tariff 1 in kWh")]
    public double TotalPowerExportT1Kwh { get; set; }
    
    [JsonPropertyName("active_power_w")]
    [DataModelProperty(Name = "Active Power", Affix = "W", Description = "The total active usage in watt")]
    public double ActivePowerW { get; set; }

    [JsonPropertyName("active_power_l1_w")]
    [DataModelProperty(Name = "Active Power L1", Affix = "W", Description = "The active usage for phase 1 in watt")]
    public double ActivePowerL1W { get; set; }
}