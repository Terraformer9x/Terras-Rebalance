using HarmonyLib;

namespace TerrasRebalance.Patches;

[HarmonyPatch(typeof(StartOfRound))]
public class ItemPatch
{
    [HarmonyPatch(typeof(StartOfRound), "Awake")]
    [HarmonyPostfix]
    private static void ChangeItemData()
    {
        foreach (Item item in StartOfRound.Instance.allItemsList.itemsList)
        {
            switch (item.name)
            {
                case "Shovel":	
                    if (TerrasRebalanceConfig.changeShovelWeight.Value) item.weight = 1.08f;
                    break;
                case "StopSign":
                    if (TerrasRebalanceConfig.changeStopSignWeight.Value) item.weight = 1.2f;
                    break;
                case "Jetpack":
                    if (TerrasRebalanceConfig.changeJetpackPrice.Value) item.creditsWorth = 700;
                    break;
            }
        }
    }
}