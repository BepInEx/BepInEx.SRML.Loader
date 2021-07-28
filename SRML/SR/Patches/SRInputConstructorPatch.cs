using HarmonyLib;
using System.Reflection;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(SRInput))]
    internal static class SRInputConstructorPatch
    {
        public static MethodBase TargetMethod()
        {
            return AccessTools.Constructor(typeof(SRInput));
        }
        public static void Postfix(SRInput __instance)
        {
            foreach (var v in BindingRegistry.precreators) v(__instance.actions);
        }
    }
}
