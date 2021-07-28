using HarmonyLib;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(PlayerState))]
    [HarmonyPatch("CheckAllUpgradeLockers")]
    internal static class PlayerStateNullCheckPatches
    {
        public static bool Prefix(PlayerState __instance)
        {
            if (__instance.model == null) return false;
            return true;
        }
    }
}
