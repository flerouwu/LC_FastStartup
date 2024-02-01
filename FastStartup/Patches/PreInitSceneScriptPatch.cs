using FastStartup.TimeSavers;
using HarmonyLib;

namespace FastStartup.Patches;

// ReSharper disable InconsistentNaming
[HarmonyPatch(typeof(PreInitSceneScript))]
public static class PreInitSceneScriptPatch {
    [HarmonyPrefix]
    [HarmonyPatch("SkipToFinalSetting")]
    public static bool SkipToFinalSetting(PreInitSceneScript __instance) {
        if (!Plugin.Config.SkipLaunchMode.Value) return true;
        
        __instance.launchSettingsPanelsContainer.SetActive(false);
        LaunchOptionsSaver.Start();
        return false;
    }
}
