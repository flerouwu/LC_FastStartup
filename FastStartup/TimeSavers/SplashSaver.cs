using System;
using System.Threading;
using System.Threading.Tasks;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.Rendering;
using Logger = BepInEx.Logging.Logger;

namespace FastStartup.TimeSavers;

/// <summary>
///     Skips the movie startup splashes that play when
///     the game is initially opened. This includes the
///     "Made with Unity" and Zeekerss' logo.
/// </summary>
internal static class SplashSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.Splash");

    static SplashSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal static void Start() {
        if (!Plugin.Config.SkipSplashes.Value) return;
        Task.Factory.StartNew(() => {
            var delay = Plugin.Config.SplashDelay.Value;
            var duration = Plugin.Config.SplashDuration.Value;
            if (delay > 0) {
                LogSource.LogInfo($"Waiting for {delay} seconds before skipping splashes.");
                Thread.Sleep(TimeSpan.FromSeconds(delay));
            }

            LogSource.LogInfo($"Trying to stop splash screen. Cancelling after {duration} seconds.");

            // I was unable to find any better way to do this.
            // I was hoping that there was some kind of event I could listen for,
            // or if I could just do this once when the mod was loaded, but I
            // found no luck.
            // - flerouwu
            while (!LaunchOptionsSaver.HasRan) {
                SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
                if (Time.realtimeSinceStartup < duration) continue;
                
                LogSource.LogError($"Failed to remove splash screen: {duration} seconds has passed since startup!");
                break;
            }
        });
    }
}
