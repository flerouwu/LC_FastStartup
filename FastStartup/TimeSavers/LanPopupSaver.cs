using BepInEx.Logging;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;

namespace FastStartup.TimeSavers;

/// <summary>
///     Disables the warning popup when you
///     launch into LAN mode.
/// </summary>
internal static class LanPopupSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.LanPopup");

    static LanPopupSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal static void Start() {
        if (!Plugin.Config.DisableLanPopup.Value) return;
        var obj = Object.FindObjectOfType<MenuManager>();
        if (obj == null) return;

        LogSource.LogInfo("Destroying LAN popup");
        Object.Destroy(obj.lanWarningContainer);
    }
}
