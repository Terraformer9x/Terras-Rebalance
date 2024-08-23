using HarmonyLib;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(ButlerEnemyAI))]
public class ButlerPatch
{
    [HarmonyPatch(nameof(ButlerEnemyAI.Start))]
    [HarmonyPostfix]
    private static void ChangeButlerHealth(ref ButlerEnemyAI __instance)
    {
        __instance.enemyHP = 4;
    }
}