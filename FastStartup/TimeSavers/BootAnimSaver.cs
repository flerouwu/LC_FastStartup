using BepInEx.Logging;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;

namespace FastStartup.TimeSavers;

/// <summary>
///     Removes the boot animation.
///     The boot animation is the terminal-like startup
///     just before the menu is rendered.
/// </summary>
internal class BootAnimSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.BootAnim");

    internal BootAnimSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal void Start() {
        if (!Plugin.Config.SkipBootAnim.Value) return;
        var game = Object.FindObjectOfType<InitializeGame>();
        if (game == null) return;

        LogSource.LogInfo("Skipping boot animation");
        game.runBootUpScreen = false;

        // Set animations to null just in case :3
        game.bootUpAnimation = null;
        game.bootUpAudio = null;
    }
}
