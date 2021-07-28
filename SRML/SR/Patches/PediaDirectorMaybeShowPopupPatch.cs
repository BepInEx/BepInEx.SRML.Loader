using HarmonyLib;
using System;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(PediaDirector))]
    [HarmonyPatch("MaybeShowPopup", new Type[] { typeof(PediaDirector.Id) })]
    internal static class PediaDirectorMaybeShowPopupPatch
    {
        public static bool Prefix(PediaDirector __instance, PediaDirector.Id id)
        {
            if (__instance.entryDict.ContainsKey(id))
            {
                return true;
            }

            __instance.UnlockWithoutPopup(id);
            return false;
        }
    }
}
