using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;


namespace SafetyShotgun.Patches
{
    [HarmonyPatch(typeof(ShotgunItem))]
    internal class ShowShotgunMode 
    {

        //[HarmonyPatch(nameof(ShotgunItem.EquipItem))]
        //[HarmonyPrefix]
        //public static void enableGUI()
        //{
        //    SSG.Instance.mod.Visible = true;
        //}

        //[HarmonyPatch(nameof(ShotgunItem.PocketItem))]
        //[HarmonyPrefix]
        //public static void DisableGUI()
        //{
        //    SSG.Instance.mod.Visible = false;
        //}


        [HarmonyPatch(nameof(ShotgunItem.ItemInteractLeftRight))]
        [HarmonyPrefix]
        public static void ChangeGUI()
        {
            SSG.Instance.mod.IsSafetyOn = true;
        }
    }
}

//safetyOn