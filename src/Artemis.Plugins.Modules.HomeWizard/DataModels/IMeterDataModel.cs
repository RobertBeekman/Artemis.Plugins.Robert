using System.Net.Http;
using System.Threading.Tasks;

namespace Artemis.Plugins.Modules.HomeWizard.DataModels;

public interface IMeterDataModel
{
    Task Update(HttpClient client);
}