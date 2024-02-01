using BepInEx;
using FastStartup.TimeSavers;
using UnityEngine.SceneManagement;

namespace FastStartup;

[BepInPlugin(ModId, ModName, ModVersion)]
public class Plugin : BaseUnityPlugin {
    public const string ModId = "dev.flero.lethal.FastStartup";
    public const string ModName = "FastStartup";
    public const string ModVersion = "1.1.1";

    public new static Config.Config Config { get; private set; }
    public static bool Initialized { get; private set; }

    internal static void Initialize() {
        if (Initialized) return;
        Initialized = true;
    }


    #region Unity Events
    private void Awake() {
        Logger.LogInfo("Loading Configuration");
        Config = new Config.Config(base.Config);

        SceneManager.sceneLoaded += OnSceneLoaded;
        Logger.LogInfo($"Plugin {ModId} is loaded!");

        // Skip splash
        new SplashSaver().Start();
    }

    private void Start() {
        Initialize();
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        switch (scene.name) {
            // Launch Mode scene
            case "InitSceneLaunchOptions":
                new LaunchOptionsSaver().Start();
                break;

            // Boot Animation scene
            case "InitScene":
            case "InitSceneLANMode":
                BootAnimSaver.Start();
                break;

            // Main menu (obviously)
            case "MainMenu":
                MenuAnimSaver.Start();
                LanPopupSaver.Start();
                break;
        }
    }

    private void Initialize() {
        if (Initialized) return;
        Initialized = true;
        
        Logger.LogInfo("Loading Configuration");
        Config = new Config.Config(base.Config);

        SceneManager.sceneLoaded += OnSceneLoaded;
        Logger.LogInfo($"Plugin {ModId} is loaded!");
    }


    #region Unity Events
    private void Awake() {
        Initialize();
        SplashSaver.Start();
    }

    private void Start() {
        Initialize();
    }
    #endregion
}
