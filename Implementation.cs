using Harmony;
using MelonLoader;
using UnityEngine;

namespace SkipIntroRedux
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
        }
    }
    // Skip Disclaimer 
    // Seems like they obfuscate call to GAMEPLAY_Disclaimer 
    // Anyway this will work but disclaimer will be seen (until all resources is loaded)
    // So no clicks/keypress required 
    [HarmonyPatch(typeof(BootUpdate), "Start")]
    public class SkipIntroReduxSkipDisclaimer
    {
        public static void Postfix(BootUpdate __instance)
        {
            __instance.LoadMainMenu();
        }
    }

    // Skip Intro 
    [HarmonyPatch(typeof(Panel_MainMenu), "Enable")]
    public class SkipIntroReduxSkipIntro
    {
        public static void Prefix(Panel_MainMenu __instance)
        {
            MoviePlayer.m_HasIntroPlayedForMainMenu = true;
        }
    }
}
