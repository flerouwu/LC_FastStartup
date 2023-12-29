using BepInEx.Configuration;

namespace FastStartup;

public class Config {
    public readonly ConfigEntry<bool> SkipLaunchMode;
    public readonly ConfigEntry<LaunchMode> AutoLaunchMode;

    public readonly ConfigEntry<bool> SkipBootAnim;
    public readonly ConfigEntry<bool> SkipMenuAnim;
    public readonly ConfigEntry<bool> SkipSplashes;

    public readonly ConfigEntry<bool> DisableLanPopup;

    public Config(ConfigFile file) {
        // LaunchMode
        SkipLaunchMode = file.Bind("LaunchMode", "Enabled", true, "Whether we should skip the launch mode screen.");
        AutoLaunchMode = file.Bind("LaunchMode", "DefaultLaunchMode", LaunchMode.Online,
            "Default mode to launch into.");

        // Skips
        SkipBootAnim = file.Bind("Skips", "BootAnim", true,
            "Whether we should skip the terminal-like boot animation.");
        SkipMenuAnim = file.Bind("Skips", "MenuAnim", true,
            "Whether we should skip the small squash animation of the main menu.");
        SkipSplashes = file.Bind("Skips", "SplashScreens", true, "Whether we should skip the splash screens.");

        // Misc
        DisableLanPopup = file.Bind("Misc", "DisableLanPopup", true,
            "Whether to disable the 'You are in LAN mode' popup.");
    }
}

// ReSharper disable once UnusedMember.Global
public enum LaunchMode {
    Online,
    Lan
}
