using HarmonyLib;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(PediaDirector))]
    [HarmonyPatch("Awake")]
    internal static class PediaDirectorAwakePatch
    {
        public static void Prefix(PediaDirector __instance)
        {
            __instance.entries = __instance.entries.AddRangeToArray(PediaRegistry.customEntries.ToArray());
            __instance.identMapEntries = __instance.identMapEntries.AddRangeToArray(PediaRegistry.customIdentifiableLinks.ToArray());
            __instance.initUnlocked = __instance.initUnlocked.AddRangeToArray(PediaRegistry.initialEntries.ToArray());
        }
    }
}
