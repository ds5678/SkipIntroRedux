using Harmony;

namespace SkipIntroRedux
{
	internal static class Patches
	{
		[HarmonyPatch(typeof(BootUpdate), "Start")]
		public class BootUpdate_Start
		{
			public static void Postfix(BootUpdate __instance)
			{
				for (int i = 1; i <= 3; i++)
				{
					__instance.gameObject.transform.Find($"Label_Disclaimer_{i}")?.gameObject.SetActive(false);
				}
				__instance.LoadMainMenu();
			}
		}

		[HarmonyPatch(typeof(BootUpdate), "Update")]
		public class BootUpdate_Update
		{
			public static void Postfix(BootUpdate __instance)
			{
				__instance.m_Label_Continue.gameObject.SetActive(false);
			}
		}

		[HarmonyPatch(typeof(Panel_MainMenu), "Enable")]
		public class SkipIntroReduxSkipIntro
		{
			public static void Prefix(Panel_MainMenu __instance)
			{
				MoviePlayer.m_HasIntroPlayedForMainMenu = true;
			}
		}
	}
}
