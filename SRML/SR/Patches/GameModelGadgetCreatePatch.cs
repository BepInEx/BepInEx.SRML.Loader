using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using System.Linq;
using UnityEngine;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(GameModel))]
    [HarmonyPatch("CreateGadgetModel")]
    internal static class GameModelGadgetCreatePatch
    {
        public static bool Prefix(out GadgetModel __result, GadgetSiteModel site, GameObject gameObj)
        {
            __result = null;
            var id = gameObj.GetComponent<Gadget>().id;
            var _override = DataModelRegistry.gadgetOverrideMapping.FirstOrDefault((x) => x.Key(id));
            if (_override.Value == null)
                return true;

            __result = _override.Value(site, gameObj);
            return false;
        }
    }
}
