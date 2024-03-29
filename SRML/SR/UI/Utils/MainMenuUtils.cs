﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace SRML.SR.UI.Utils
{
    public static class MainMenuUtils
    {
        public static GameObject DisplayBlankPanel<T>(MainMenuUI mainMenu, string title, Action onClose = null) where T : BaseUI
        {
            var h = GameObject.Instantiate(mainMenu.optionsUI);
            Component.DestroyImmediate(h.GetComponent<OptionsUI>());

            for (int i = 0; i < h.transform.GetChild(0).childCount; i++)
            {
                var v = h.transform.GetChild(0).GetChild(i).gameObject;
                if (v.name == "CloseButton")
                {
                    v.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                    v.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        GameObject.Destroy(h);
                        onClose?.Invoke();
                    });
                }
                else if (v.name == "Title" && title != null)
                {
                    v.GetComponent<TMP_Text>().text = title;
                }
                else
                {
                    GameObject.Destroy(v);
                }
            }


            mainMenu.gameObject.SetActive(false);
            var baseUI = h.AddComponent<T>();
            baseUI.onDestroy += () =>
            {
                if (mainMenu)
                {
                    mainMenu.gameObject.SetActive(true);
                }
            };
            return h;
        }


        public static GameObject AddMainMenuButton(MainMenuUI mainMenu, String text, Action onClicked)
        {
            var mode = mainMenu.transform.Find("StandardModePanel/OptionsButton");
            var g = GameObject.Instantiate(mode.gameObject);
            g.transform.SetParent(mode.parent, false);
            g.transform.localPosition = new Vector3(0, 0);
            MonoBehaviour.Destroy(g.GetComponent<XlateText>());
            var button = g.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(new UnityAction(onClicked));

            g.GetComponentInChildren<TMP_Text>().text = text;

            return g;
        }


    }

}
