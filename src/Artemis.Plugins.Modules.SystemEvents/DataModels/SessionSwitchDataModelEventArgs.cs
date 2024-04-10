using Artemis.Core;
using Artemis.Core.Modules;
using Microsoft.Win32;

namespace Artemis.Plugins.Modules.SystemEvents.DataModels;

public class SessionSwitchDataModelEventArgs : DataModelEventArgs
{
    public SessionSwitchDataModelEventArgs(SessionSwitchReason reason)
    {
        Reason = reason;
    }

    [DataModelProperty(Name = "Session Switch Reason", Description = "The reason for the session switch")]
    public SessionSwitchReason Reason { get; set; }
}