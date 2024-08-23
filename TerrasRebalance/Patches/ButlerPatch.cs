using HarmonyLib;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(ButlerEnemyAI))]
public class ButlerPatch
{
    [HarmonyPatch(nameof(ButlerEnemyAI.Start))]
    [HarmonyPostfix]
    private static void ChangeButlerHealth(ref ButlerEnemyAI __instance)
    {
        if (StartOfRound.Instance.connectedPlayersAmount > 0)
        {
            __instance.enemyHP = 4;
        }
    }
}