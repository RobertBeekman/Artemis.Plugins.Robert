using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Threading;
using Artemis.Core.Modules;
using Artemis.Plugins.Modules.SystemEvents.DataModels;
using Microsoft.Win32;
using Serilog;

namespace Artemis.Plugins.Modules.SystemEvents;

[SupportedOSPlatform("windows")]
public class SystemEventsModule : Module<SystemEventsDataModel>
{
    private readonly ILogger _logger;
    public override List<IModuleActivationRequirement> ActivationRequirements { get; } = [];

    public SystemEventsModule(ILogger logger)
    {
        _logger = logger;
    }

    public override void Enable()
    {
        Subscribe();
    }

    public override void Disable()
    {
        Unsubscribe();
    }

    public override void Update(double deltaTime)
    {
    }

    private void Subscribe()
    {
        Thread thread = new(() =>
        {
            try
            {
                Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEventsOnPowerModeChanged;
                Microsoft.Win32.SystemEvents.UserPreferenceChanged += SystemEventsOnUserPreferenceChanged;
                Microsoft.Win32.SystemEvents.SessionSwitch += SystemEventsOnSessionSwitch;
            }
            catch (Exception e)
            {
                _logger.Warning(e, "Could not subscribe to system events");
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }

    private void Unsubscribe()
    {
        Thread thread = new(() =>
        {
            Microsoft.Win32.SystemEvents.PowerModeChanged -= SystemEventsOnPowerModeChanged;
            Microsoft.Win32.SystemEvents.UserPreferenceChanged -= SystemEventsOnUserPreferenceChanged;
            Microsoft.Win32.SystemEvents.SessionSwitch -= SystemEventsOnSessionSwitch;
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }

    private void SystemEventsOnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        DataModel.UserPreferenceChanged.Trigger(new UserPreferenceCategoryDataModelEventArgs(e.Category));
    }

    private void SystemEventsOnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        DataModel.PowerModeChanged.Trigger(new PowerModeDataModelEventArgs(e.Mode));
    }

    private void SystemEventsOnSessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        DataModel.SessionSwitch.Trigger(new SessionSwitchDataModelEventArgs(e.Reason));
    }
}