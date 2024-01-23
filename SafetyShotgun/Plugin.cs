using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SafetyShotgun.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SafetyShotgun
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class SSG : BaseUnityPlugin
    {
        private const string modGUID = "Gurumne.SafetyShotgun";
        private const string modName = "Safety Shotgun";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static SSG Instance;

        internal GUItoMod mod;
        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("The SafetyShotgun mod has awaken");

            harmony.PatchAll(typeof(SSG));
            harmony.PatchAll(typeof(ShowShotgunMode));

            mls = Logger;

            Task.Delay(2000).ContinueWith(t => { CreateMenu(); });
        }

        private void CreateMenu()
        {
            var gameObject = new UnityEngine.GameObject("ShowShotgun");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<GUItoMod>();
            mod = (GUItoMod)gameObject.GetComponent("ShowShotgun");
        }
    }
}
