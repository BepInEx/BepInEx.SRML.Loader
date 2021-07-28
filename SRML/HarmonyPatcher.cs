using HarmonyLib;
using SRML.Patches;

namespace SRML
{
    /// <summary>
    /// Utility class to help manage the main SRML harmony instance
    /// </summary>
    public static class HarmonyPatcher
    {
        internal static Harmony Instance { get; } = new Harmony("net.veesus.srml");

        internal static void PatchAll()
        {
            Instance.PatchAll(typeof(EnumInfoPatch));
        }

        public static Harmony SetInstance(string name)
        {
            var currentMod = SRMod.GetCurrentMod();
            currentMod.CreateHarmonyInstance(name);
            return currentMod.HarmonyInstance;
        }

        public static Harmony GetInstance()
        {
            return SRMod.GetCurrentMod().HarmonyInstance;
        }
    }
}