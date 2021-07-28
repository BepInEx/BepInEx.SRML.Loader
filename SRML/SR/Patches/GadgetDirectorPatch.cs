using HarmonyLib;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(GadgetDirector))]
    [HarmonyPatch("IsRefineryResource")]
    internal static class GadgetDirectorPatch
    {
        public static void Postfix(ref bool __result, Identifiable.Id id)
        {
            __result = __result || AmmoRegistry.customRefineryResources.Contains(id);
        }
    }
}
