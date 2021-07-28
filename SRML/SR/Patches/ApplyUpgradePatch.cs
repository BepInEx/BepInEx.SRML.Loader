using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(PlayerModel))]
    [HarmonyPatch("ApplyUpgrade")]
    internal static class ApplyUpgradePatch
    {
        public static bool Prefix(PlayerModel __instance, PlayerState.Upgrade upgrade, bool isFirstTime)
        {
            if (PersonalUpgradeRegistry.upgradeCallbacks.TryGetValue(upgrade, out var callback))
            {
                callback(__instance, isFirstTime);
                return false;
            }

            return true;
        }
    }
}
