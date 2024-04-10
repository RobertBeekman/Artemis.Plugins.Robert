using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Modules.SystemEvents.DataModels;

public class SystemEventsDataModel : DataModel
{

    [DataModelProperty(Name = "Power Mode Changed", Description = "Triggered when the power mode changes")]
    public DataModelEvent<PowerModeDataModelEventArgs> PowerModeChanged { get; set; } = new();

    [DataModelProperty(Name = "User Preference Changed", Description = "Triggered when a user preference changes")]
    public DataModelEvent<UserPreferenceCategoryDataModelEventArgs> UserPreferenceChanged { get; set; } = new();

    [DataModelProperty(Name = "Session Switch", Description = "Triggered when a session switch occurs")]
    public DataModelEvent<SessionSwitchDataModelEventArgs> SessionSwitch { get; set; } = new();
}