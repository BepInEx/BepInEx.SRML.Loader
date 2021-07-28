using HarmonyLib;
using InControl;
using MonomiPark.SlimeRancher;
using System.Collections.Generic;
using System.Linq;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(SavedProfile))]
    [HarmonyPatch("PullBindings")]
    internal static class SavedProfilePullBindingsPatch
    {
        public static void Prefix(ref IEnumerable<PlayerAction> actions)
        {
            actions = actions.Where(x => !BindingRegistry.IsModdedAction(x));
        }
    }
}
