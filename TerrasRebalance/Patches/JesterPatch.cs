using HarmonyLib;
using UnityEngine;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(JesterAI))]
public class JesterPatch
{
    [HarmonyPatch(nameof(JesterAI.Start))]
    [HarmonyPostfix]
    private static void ChangeJesterTimer(ref JesterAI __instance)
    {
        __instance.beginCrankingTimer = Random.Range(25f, 42f);
    }

    [HarmonyPatch(nameof(JesterAI.Update))]
    [HarmonyPostfix]
    private static void SlamOpenDoors(ref JesterAI __instance)
    {
        if (__instance.currentBehaviourStateIndex == 2 && __instance.agent.speed >= 10f)
        {
            __instance.useSecondaryAudiosOnAnimatedObjects = true;
        }
        else
        {
            __instance.useSecondaryAudiosOnAnimatedObjects = false;
        }
    }
}