using HarmonyLib;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(MainMenuUI))]
    [HarmonyPatch("Start")]
    internal static class MainMenuStartPatch
    {
        public static void Postfix(MainMenuUI __instance)
        {
            SRCallbacks.OnMainMenuLoad(__instance);
        }
    }
}
