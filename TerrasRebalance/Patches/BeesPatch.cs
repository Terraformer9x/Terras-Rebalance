﻿using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(RedLocustBees))]
public class CircuitBeesPatch
{
    [HarmonyPatch(nameof(RedLocustBees.Start))]
    [HarmonyPostfix]
    private static void Postfix(RedLocustBees __instance)
    {
        __instance.openDoorSpeedMultiplier = 0f;
    }
}

[HarmonyPatch(typeof(ButlerBeesEnemyAI))]
public class ButlerBeesPatch
{
    [HarmonyPatch(nameof(ButlerBeesEnemyAI.Start))]
    [HarmonyPostfix]
    private static void Postfix(ButlerBeesEnemyAI __instance)
    {
        __instance.openDoorSpeedMultiplier = 0f;
    }

    [HarmonyPatch(nameof(ButlerBeesEnemyAI.DoAIInterval))]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> SpeedPatch(IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> list = instructions.ToList();
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 4.25f)
            {
                list[i] = new CodeInstruction(OpCodes.Ldc_R4, 5.4f);
                break;
            }
        }

        return list;
    }
}