using UnityEngine;

namespace SRML.Utils.Prefab.Patches
{
    //aa [HarmonyPatch(typeof(UnityEngine.Object))]
    // [HarmonyPatch("Destroy")]
    internal static class GameObjectDestroyPatch
    {
        public static bool Prefix(UnityEngine.Object obj)
        {
            return (obj is GameObject g) ? ((!g.GetComponent<RuntimePrefab>()?.AvoidDestroy) ?? true) : true;
        }
    }

    //[HarmonyPatch(typeof(UnityEngine.Object))]
    //[HarmonyPatch("DestroyImmediate")]
    internal static class GameObjectDestroyImmediatePatch
    {
        public static bool Prefix(UnityEngine.Object obj)
        {
            return (obj is GameObject g) ? ((!g.GetComponent<RuntimePrefab>()?.AvoidDestroy) ?? true) : true;
        }
    }
}
