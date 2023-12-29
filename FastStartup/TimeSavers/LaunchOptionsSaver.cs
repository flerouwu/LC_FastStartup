using BepInEx.Logging;
using UnityEngine.SceneManagement;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the launch mode menu and
///     automatically loads into online.
/// </summary>
internal class LaunchOptionsSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.LaunchOptions");

    internal LaunchOptionsSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal void Start() {
        Plugin.Initialize();

        LogSource.LogInfo("Skipping launch options, defaulting to online mode.");
        SceneManager.LoadScene("InitScene");
    }
}
