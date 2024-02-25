using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Modules.HomeWizard.DataModels;

public class HomeWizardDataModel : DataModel
{
    private readonly List<IMeterDataModel> _meters = new();

    public void AddMeter(IMeterDataModel meterDataModel, string key, string description)
    {
        _meters.Add(meterDataModel);
        AddDynamicChild(key, meterDataModel, description);
    }

    public void ClearMeters()
    {
        _meters.Clear();
        ClearDynamicChildren();
    }

    public async Task Update(HttpClient httpClient)
    {
        foreach (IMeterDataModel meterDataModel in _meters)
            await meterDataModel.Update(httpClient);
    }
}