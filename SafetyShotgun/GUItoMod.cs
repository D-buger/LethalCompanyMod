using BepInEx;
using SafetyShotgun.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SafetyShotgun
{
    internal class GUItoMod : MonoBehaviour
    {
        internal static GUItoMod Instance;

        internal bool Visible = true;
        internal bool IsSafetyOn = false;

        private GUIStyle redGUI;
        private GUIStyle greenGUI;
        private const int MENU_WIDTH = 400;
        private const int MENU_HEIGHT = 400;
        private int menuX;
        private int menuY;

        private bool Initialized = false;

        void Awake()
        {
            if (null == Instance)
            {
                Instance = this;
            }

            menuX = UnityEngine.Device.Screen.width / 8;
            menuX = UnityEngine.Device.Screen.width / 10;
        }

        void Update()
        {

        }

        private void InitializeGUI()
        {
            if (null == redGUI)
            {
                redGUI = new GUIStyle(GUI.skin.label);
                greenGUI = new GUIStyle(GUI.skin.label);

                redGUI.normal.textColor = Color.white;
                redGUI.normal.background = MakeTex(200, 200, new Color(1.0f, 0f, 0f, 1.0f));
                redGUI.fontSize = 18;
                redGUI.normal.background.hideFlags = HideFlags.HideAndDontSave;

                greenGUI.normal.textColor = Color.white;
                greenGUI.normal.background = MakeTex(200, 200, new Color(0f, 1.0f, 0f, 1.0f));
                greenGUI.fontSize = 18;
                greenGUI.normal.background.hideFlags = HideFlags.HideAndDontSave;
            }
        }

        public void OnGUI()
        {
            if (!Visible) { return; }
            if (!Initialized)
            {
                InitializeGUI();
                Initialized = true;
            }

            GUI.Box(new Rect(menuX, menuY, MENU_WIDTH, MENU_HEIGHT), "");
            GUI.Label(new Rect(menuX, menuY, MENU_WIDTH - 10, MENU_HEIGHT - 10), "ON", redGUI);
        }

        private Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}
