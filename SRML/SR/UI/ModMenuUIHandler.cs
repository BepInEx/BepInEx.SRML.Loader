﻿using SRML.SR.UI.Utils;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace SRML.SR.UI
{
    internal static class ModMenuUIHandler
    {
        private static GameObject mainMenuUIPrefab;
        internal static void OnMainMenuLoaded(MainMenuUI ui)
        {
            MainMenuUtils.AddMainMenuButton(ui, "Mods", () =>
            {
                var g = MainMenuUtils.DisplayBlankPanel<BaseUI>(ui, "Mods");
                GameObject.Instantiate(mainMenuUIPrefab)
                .transform.SetParent(g.transform.GetChild(0), false);

            }).transform.SetSiblingIndex(5);

            if (mainMenuUIPrefab) return;

            var bundle = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(typeof(ModMenuUIHandler), "srml"));
            var h = bundle.LoadAsset<GameObject>("ModPanel");
            h.AddComponent<ModMenuUI>().infoButtonPrefab = bundle.LoadAsset<GameObject>("ModInfoButton");
            UIUtils.FixStyles(h);
            h.GetComponent<Image>().color = Color.green;
            mainMenuUIPrefab = h;
        }


    }
}
