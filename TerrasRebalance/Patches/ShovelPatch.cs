using HarmonyLib;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(GrabbableObject))]
public class ShovelPatch
{
    [HarmonyPatch(nameof(GrabbableObject.Start))]
    [HarmonyPostfix]
    private static void ChangeItemData(ref GrabbableObject __instance)
    {
        if(__instance.itemProperties.name == "Shovel")
        {
            __instance.itemProperties.weight = 1.08f;
        }
    }
}