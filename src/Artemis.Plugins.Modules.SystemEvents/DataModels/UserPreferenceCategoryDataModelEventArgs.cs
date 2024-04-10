using Artemis.Core;
using Artemis.Core.Modules;
using Microsoft.Win32;

namespace Artemis.Plugins.Modules.SystemEvents.DataModels;

public class UserPreferenceCategoryDataModelEventArgs : DataModelEventArgs
{
    public UserPreferenceCategoryDataModelEventArgs(UserPreferenceCategory category)
    {
        Category = category;
    }

    [DataModelProperty(Name = "User Preference Category", Description = "The category of the user preference that changed")]
    public UserPreferenceCategory Category { get; set; }
}