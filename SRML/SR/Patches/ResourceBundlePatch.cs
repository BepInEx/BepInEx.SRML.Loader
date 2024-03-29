﻿using HarmonyLib;
using System.Collections.Generic;

namespace SRML.SR.Patches
{
    [HarmonyPatch(typeof(ResourceBundle))]
    [HarmonyPatch("LoadFromText")]
    internal static class ResourceBundlePatch
    {
        static void Postfix(string path, Dictionary<string, string> __result, string text)
        {
            TranslationPatcher.doneDictionaries[path] = __result;
            if (!TranslationPatcher.patches.TryGetValue(path, out var dict)) return;
            foreach (var entry in dict)
            {
                __result[entry.Key] = entry.Value;
            }


        }
    }
}
