using HarmonyLib;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(MouthDogAI))]
public class MouthDogPatch
{
    [HarmonyPatch(nameof(MouthDogAI.Start))]
    [HarmonyPostfix]
    private static void ChangeDogHealth(ref MouthDogAI __instance)
    {
        __instance.enemyHP = 10;
    }
}