using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Artemis.Core.Modules;
using Artemis.Plugins.Modules.HomeWizard.Responses;

namespace Artemis.Plugins.Modules.HomeWizard.DataModels;

internal class EnergySocketDataModel : DataModel, IMeterDataModel
{
    private readonly string _ipAddress;

    public EnergySocketDataModel(string ipAddress, DeviceResponse device)
    {
        _ipAddress = ipAddress;
        ProductName = device.ProductName;
        ProductType = device.ProductType;
        FirmwareVersion = device.FirmwareVersion;
    }

    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public string FirmwareVersion { get; set; }
    public EnergySocketDataResponse Data { get; set; } = new EnergySocketDataResponse();

    public async Task Update(HttpClient httpClient)
    {
        EnergySocketDataResponse? data = await httpClient.GetFromJsonAsync<EnergySocketDataResponse>($"http://{_ipAddress}/api/v1/data");
        if (data != null)
            Data = data;
    }
}