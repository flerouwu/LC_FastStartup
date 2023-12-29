using BepInEx.Logging;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the short menu scale animation
///     that plays when it is first opened.
/// </summary>
internal class MenuAnimSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.BootAnim");

    internal MenuAnimSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal void Start() {
        LogSource.LogInfo("Disabling menu open animation");
        GameNetworkManager.Instance.firstTimeInMenu = false;
    }
}
