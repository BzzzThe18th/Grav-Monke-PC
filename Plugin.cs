using BepInEx;
using System;
using System.ComponentModel;
using UnityEngine;
using Utilla;

namespace GravMonke
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.3")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [Description("HauntedModMenu")]
    public class Plugin : BaseUnityPlugin
    {
        public static bool inRoom;
        static Vector3 gravityWas;

        public static void resetGravity()
        {
            Physics.gravity = gravityWas;
            Debug.Log("Reset gravity");
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            resetGravity();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            gravityWas = Physics.gravity;
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
            resetGravity();
        }
    }
}
