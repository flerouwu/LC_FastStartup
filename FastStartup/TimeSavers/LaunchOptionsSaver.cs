using System;
using BepInEx.Logging;
using FastStartup.Config;
using UnityEngine.SceneManagement;
using Logger = BepInEx.Logging.Logger;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the launch mode menu and
///     automatically loads into online.
/// </summary>
internal static class LaunchOptionsSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.LaunchOptions");
    private static bool HasRan;

    static LaunchOptionsSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal static void Start() {
        if (!Plugin.Config.SkipLaunchMode.Value) return;
        if (HasRan) return;
        HasRan = true;

        Plugin.Initialize();

        var mode = Plugin.Config.AutoLaunchMode.Value;
        LogSource.LogInfo($"Skipping launch options, defaulting to {Plugin.Config.AutoLaunchMode.Value}.");
        switch (mode) {
            case LaunchMode.Online:
                SceneManager.LoadScene("InitScene");
                break;

            case LaunchMode.Lan:
                SceneManager.LoadScene("InitSceneLANMode");
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
