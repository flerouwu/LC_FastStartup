using BepInEx.Logging;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the short menu scale animation
///     that plays when it is first opened.
/// </summary>
internal class MenuAnimSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.MenuAnim");

    internal MenuAnimSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal void Start() {
        if (!Plugin.Config.SkipMenuAnim.Value) return;
        LogSource.LogInfo("Disabling menu open animation");
        GameNetworkManager.Instance.firstTimeInMenu = false;
    }
}
