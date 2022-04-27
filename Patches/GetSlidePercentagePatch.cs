using HarmonyLib;
using System;
using UnityEngine;

namespace GravMonke.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("GetSlidePercentage", MethodType.Normal)]
    internal class GetSlidePercentagePatch
    {
        static void Postfix(RaycastHit raycastHit)
        {
            if(Plugin.inRoom) Physics.gravity = raycastHit.normal * -9.81f;
        }
    }
}