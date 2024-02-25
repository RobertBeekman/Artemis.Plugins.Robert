using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Plugins.Modules.HomeWizard.DataModels;
using Artemis.Plugins.Modules.HomeWizard.Responses;
using Serilog;
using Zeroconf;

namespace Artemis.Plugins.Modules.HomeWizard;

[PluginFeature(Name = "HomeWizard Meters")]
public class HomeWizardModule : Module<HomeWizardDataModel>
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public HomeWizardModule(ILogger logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public override List<IModuleActivationRequirement> ActivationRequirements { get; } = new();


    public override void Enable()
    {
        Task.Run(GetMeters);
        AddTimedUpdate(TimeSpan.FromSeconds(1), async _ => await UpdateDevices(), "Update devices");
    }

    public override void Disable()
    {
    }

    public override void Update(double deltaTime)
    {
    }

    private async Task GetMeters()
    {
        IReadOnlyList<IZeroconfHost> results = await ZeroconfResolver.ResolveAsync("_hwenergy._tcp.local.");

        DataModel.ClearMeters();
        foreach (IZeroconfHost host in results)
            await AddMeter(host);
    }

    private async Task AddMeter(IZeroconfHost host)
    {
        DeviceResponse? device = await _httpClient.GetFromJsonAsync<DeviceResponse>($"http://{host.IPAddress}/api");
        if (device == null)
        {
            _logger.Warning("Got invalid response from {DisplayName} at {Ip}", host.DisplayName, host.IPAddress);
            return;
        }

        // P1 meter
        if (device.ProductType == "HWE-P1")
            DataModel.AddMeter(new P1MeterDataModel(host.IPAddress, device), device.Serial, $"{device.ProductName} ({device.Serial})");
        // Energy Socket
        else if (device.ProductType == "HWE-SKT")
            DataModel.AddMeter(new EnergySocketDataModel(host.IPAddress, device), device.Serial, $"{device.ProductName} ({device.Serial})");
    }

    private async Task UpdateDevices()
    {
        await DataModel.Update(_httpClient);
    }
}