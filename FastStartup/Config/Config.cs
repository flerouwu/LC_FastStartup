using BepInEx.Configuration;
using BepInEx.Logging;

namespace FastStartup.Config;

public class Config {
    private const int CurrentVersion = 2;
    private readonly ManualLogSource LogSource = new("FastStartup > Config");
    internal readonly ConfigFile File;

    public readonly ConfigEntry<int> ConfigVersion;

    public readonly ConfigEntry<bool> SkipLaunchMode;
    public readonly ConfigEntry<LaunchMode> AutoLaunchMode;
    public readonly ConfigEntry<bool> DisableLanPopup;

    public readonly ConfigEntry<bool> SkipMenuAnim;
    public readonly ConfigEntry<bool> SkipBootAnim;

    public readonly ConfigEntry<bool> SkipSplashes;
    public readonly ConfigEntry<int> SplashDelay;
    public readonly ConfigEntry<int> SplashDuration;

    public Config(ConfigFile file) {
        File = file;
        Logger.Sources.Add(LogSource);

        new ConfigBuilder<int>(this)
            .SetSection("FastStartup")
            .SetKey("ConfigVersion")
            .SetDefault(CurrentVersion)
            .SetDescription("Version of this configuration file. DO NOT CHANGE THIS")
            .Build(out ConfigVersion);

        if (ConfigVersion.Value < CurrentVersion) {
            LogSource.LogWarning("You are using an outdated config file! This may cause issues.");
            LogSource.LogWarning(
                "It is recommended to regenerate the config by removing the file and restarting Lethal Company.");
        } else if (ConfigVersion.Value > CurrentVersion) {
            LogSource.LogWarning("You are using an outdated mod version with a newer config version!");
            LogSource.LogWarning("This is not supported. Please delete the config file to regenerate it.");
        }


        #region [LaunchMode]
        new ConfigBuilder<bool>(this)
            .SetSection("LaunchMode")
            .SetKey("Enabled")
            .SetDefault(true)
            .SetDescription("Whether we should skip the launch mode screen.")
            .Build(out SkipLaunchMode);

        new ConfigBuilder<LaunchMode>(this)
            .SetSection("LaunchMode")
            .SetKey("DefaultMode")
            .SetDefault(LaunchMode.Online)
            .SetDescription("Default mode to launch into.")
            .Build(out AutoLaunchMode);

        new ConfigBuilder<bool>(this)
            .SetSection("LaunchMode")
            .SetKey("DisableLanPopup")
            .SetDefault(true)
            .SetDescription("Whether to disable the 'You are in LAN mode' popup.")
            .Build(out DisableLanPopup);
        #endregion


        #region [Splashes]
        new ConfigBuilder<bool>(this)
            .SetSection("Splashes")
            .SetKey("Enabled")
            .SetDefault(true)
            .SetDescription("Whether we should skip the splash screens.")
            .Build(out SkipSplashes);

        new ConfigBuilder<int>(this)
            .SetSection("Splashes")
            .SetKey("Delay")
            .SetDefault(0)
            .SetDescription("Delay in seconds before starting the splash skip.")
            .Build(out SplashDelay);

        new ConfigBuilder<int>(this)
            .SetSection("Splashes")
            .SetKey("Duration")
            .SetDefault(15)
            .SetDescription("Duration in seconds of how long the loop runs for before cancelling.")
            .Build(out SplashDuration);
        #endregion


        #region [Skips]
        new ConfigBuilder<bool>(this)
            .SetSection("Skips")
            .SetKey("BootAnim")
            .SetDefault(true)
            .SetDescription("Whether we should skip the terminal-like boot animation.")
            .Build(out SkipBootAnim);

        new ConfigBuilder<bool>(this)
            .SetSection("Skips")
            .SetKey("MenuAnim")
            .SetDefault(true)
            .SetDescription("Whether we should skip the small squash animation of the main menu.")
            .Build(out SkipMenuAnim);
        #endregion


        // Note: "Skips.SplashScreens" was deprecated and moved to "Splashes.Enabled".
        // Note: "Misc.DisableLanPopup" was deprecated and moved to "LaunchMode.DisableLanPopup".
    }
}
