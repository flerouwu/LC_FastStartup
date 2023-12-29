using BepInEx;
using FastStartup.TimeSavers;
using UnityEngine.SceneManagement;

namespace FastStartup;

[BepInPlugin(ModId, ModName, ModVersion)]
public class Plugin : BaseUnityPlugin {
    public const string ModId = "dev.flero.lethal.FastStartup";
    public const string ModName = "FastStartup";
    public const string ModVersion = "1.0.0";

    public static bool Initialized { get; private set; }

    internal static void Initialize() {
        if (Initialized) return;
        Initialized = true;
    }

    #region Unity Events
    private void Awake() {
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
                new BootAnimSaver().Start();
                break;

            // Main menu (obviously)
            case "MainMenu":
                new MenuAnimSaver().Start();
                break;
        }
    }
    #endregion
}
