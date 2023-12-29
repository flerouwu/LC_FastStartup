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
internal class SplashSaver {
    private static readonly ManualLogSource LogSource = new($"{Plugin.ModName}.Savers.Splash");

    internal SplashSaver() {
        Logger.Sources.Add(LogSource);
    }

    internal void Start() {
        if (!Plugin.Config.SkipSplashes.Value) return;
        Task.Factory.StartNew(() => {
            LogSource.LogInfo("Trying to stop splash screen.");

            // I was unable to find any better way to do this.
            // I was hoping that there was some kind of event I could listen for,
            // or if I could just do this once when the mod was loaded, but I
            // found no luck.
            // - flerouwu
            while (!Plugin.Initialized) {
                SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);

                if (!(Time.realtimeSinceStartup > 10)) continue;
                LogSource.LogError("Failed to remove splash screen: 10 seconds has passed since startup!");
                break;
            }
        });
    }
}
