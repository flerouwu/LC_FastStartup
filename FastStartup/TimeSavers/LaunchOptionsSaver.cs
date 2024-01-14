using System;
using BepInEx.Logging;
using FastStartup.Config;
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
        if (!Plugin.Config.SkipLaunchMode.Value) return;
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
