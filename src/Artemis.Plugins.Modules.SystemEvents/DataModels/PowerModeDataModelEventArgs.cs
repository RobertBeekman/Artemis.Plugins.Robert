using Artemis.Core;
using Artemis.Core.Modules;
using Microsoft.Win32;

namespace Artemis.Plugins.Modules.SystemEvents.DataModels;

public class PowerModeDataModelEventArgs : DataModelEventArgs
{
    public PowerModeDataModelEventArgs(PowerModes powerMode)
    {
        PowerMode = powerMode;
    }

    [DataModelProperty(Name = "Power Mode", Description = "The current power mode")]
    public PowerModes PowerMode { get; set; }
}