using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Artemis.Core.Modules;
using Artemis.Plugins.Modules.HomeWizard.Responses;

namespace Artemis.Plugins.Modules.HomeWizard.DataModels;

internal class P1MeterDataModel : DataModel, IMeterDataModel
{
    private readonly string _ipAddress;

    public P1MeterDataModel(string ipAddress, DeviceResponse device)
    {
        _ipAddress = ipAddress;
        ProductName = device.ProductName;
        ProductType = device.ProductType;
        FirmwareVersion = device.FirmwareVersion;
    }

    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public string FirmwareVersion { get; set; }
    public P1DataResponse Data { get; set; } = new P1DataResponse();

    public async Task Update(HttpClient httpClient)
    {
        P1DataResponse? data = await httpClient.GetFromJsonAsync<P1DataResponse>($"http://{_ipAddress}/api/v1/data");
        if (data != null)
            Data = data;
    }
}