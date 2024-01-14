using BepInEx.Configuration;
using BepInEx.Logging;

namespace FastStartup.Config;

internal class ConfigBuilder<T> {
    private static readonly ManualLogSource LogSource = new("FastStartup > Config");
    private readonly Config Config;
    private T Default;
    private string Description;
    private string Key;
    private string Section;

    static ConfigBuilder() {
        Logger.Sources.Add(LogSource);
    }

    public ConfigBuilder(Config config) {
        Config = config;
    }

    public void Build(out ConfigEntry<T> entry) {
        entry = Config.File.Bind(Section, Key, Default, Description);
    }

    public bool TryGet(out ConfigEntry<T> entry) => Config.File.TryGetEntry(Section, Key, out entry);


    #region Info
    public ConfigBuilder<T> SetSection(string section) {
        Section = section;
        return this;
    }

    public ConfigBuilder<T> SetKey(string key) {
        Key = key;
        return this;
    }

    public ConfigBuilder<T> SetDescription(string description) {
        Description = description;
        return this;
    }

    public ConfigBuilder<T> SetDefault(T value) {
        Default = value;
        return this;
    }
    #endregion
}
