using HarmonyLib;
using SRML.Console;
using SRML.Editor;
using SRML.SR;
using SRML.SR.Utils.BaseObjects;
using SRML.Utils;
using System;
using System.Reflection;

namespace SRML
{
    internal static class Main
    {
        private static bool isPreInitialized;

        /// <summary>
        /// Called before GameContext.Awake()
        /// </summary>
        internal static void PreLoad()
        {
            if (isPreInitialized) return;
            isPreInitialized = true;
            LogUtils.BepInExLog.LogMessage("SRML has successfully invaded the game!");

            foreach (var v in Assembly.GetExecutingAssembly().GetTypes())
            {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(v.TypeHandle);
            }

            HarmonyPatcher.PatchAll();

            try
            {
                SRModLoader.InitializeMods();
            }
            catch (Exception e)
            {
                LogUtils.BepInExLog.LogError(e);
                ErrorGUI.CreateError($"{e.GetType().Name}: {e.Message}");
                return;
            }
            
            Console.Console.Init();
            HarmonyOverrideHandler.PatchAll();
            try
            {
                SRModLoader.PreLoadMods();
            }
            catch (Exception e)
            {
                LogUtils.BepInExLog.LogError(e);
                ErrorGUI.CreateError($"{e.Message}");
                return;
            }

            ReplacerCache.ClearCache();


            HarmonyPatcher.Instance.Patch(typeof(GameContext).GetMethod("Start"),
                prefix: new HarmonyMethod(typeof(Main).GetMethod("Load",
                    BindingFlags.NonPublic | BindingFlags.Static)));
        }

        private static bool isInitialized;

        /// <summary>
        /// Called before GameContext.Start()
        /// </summary>
        static void Load()
        {
            if (isInitialized) return;
            isInitialized = true;

            BaseObjects.Populate();
            SRCallbacks.OnLoad();
            PrefabUtils.ProcessReplacements();
            KeyBindManager.ReadBinds();
            GameContext.Instance.gameObject.AddComponent<KeyBindManager.ProcessAllBindings>();
            try
            {
                SRModLoader.LoadMods();
            }
            catch (Exception e)
            {
                LogUtils.BepInExLog.LogError(e);
                ErrorGUI.CreateError($"{e.GetType().Name}: {e.Message}");
                return;
            }

            PostLoad();
        }

        private static bool isPostInitialized;

        /// <summary>
        /// Called after Load
        /// </summary>
        static void PostLoad()
        {
            if (isPostInitialized) return;
            isPostInitialized = true;
            try
            {
                SRModLoader.PostLoadMods();
            }
            catch (Exception e)
            {
                LogUtils.BepInExLog.LogError(e);
                ErrorGUI.CreateError($"{e.GetType().Name}: {e.Message}");
                return;
            }
        }
    }
}