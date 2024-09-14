using HarmonyLib;
using UnityEngine;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(JesterAI))]
public class JesterPatch
{
    [HarmonyPatch(typeof(JesterAI), "SetJesterInitialValues")]
    [HarmonyPostfix]
    private static void ChangeJesterTimer(ref JesterAI __instance)
    {
        __instance.beginCrankingTimer = Random.Range(25f, 42f);
    }
}