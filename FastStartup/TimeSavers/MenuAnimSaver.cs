using BepInEx.Logging;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the short menu scale animation
///     that plays when it is first opened.
/// </summary>
internal static class MenuAnimSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.MenuAnim");

    static MenuAnimSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal static void Start() {
        if (!Plugin.Config.SkipMenuAnim.Value) return;
        LogSource.LogInfo("Disabling menu open animation");
        GameNetworkManager.Instance.firstTimeInMenu = false;
    }
}
