using BepInEx.Configuration;
using UnityEngine.AI;

namespace TerrasRebalance;

internal class TerrasRebalanceConfig
{
    internal static ConfigEntry<bool>
        changeShovelWeight,
        changeStopSignWeight,
        changeJetpackPrice,
        changeButlerHealth,
        changeBeeBehavior,
        changeNutcrackerBehavior,
        changeMouthDogHealth,
        changeJesterTimer,
        changeStormyTimers;

    internal static void Bind(ConfigFile config)
    {
        changeShovelWeight = config.Bind(
            "Items",
            "8 lb Shovel",
            true,
            "Shovels are 8 lbs.\n\n" +
            "Disable this if you're using other mods to change the weight of Shovels."
        );
        changeStopSignWeight = config.Bind(
            "Items",
            "21 lb Stop Sign",
            true,
            "Stop Signs are 21 lbs.\n\n" +
            "Disable this if you're using other mods to change the weight of Stop Signs."
        );
        changeJetpackPrice = config.Bind(
            "Items",
            "$700 Jetpack",
            true,
            "Jetpacks are $700.\n\n" +
            "Disable this if you're using other mods to change the price of Jetpacks."
        );
        changeButlerHealth = config.Bind(
            "Entites",
            "4 HP Butlers",
            true,
            "Butlers have 4 HP on multiplayer. (It is still 2 in singleplayer)\n\n" +
            "Disable this if you're using other mods that change the behavior of Butlers."
        );
        changeBeeBehavior = config.Bind(
            "Entites",
            "Rebalanced Bees",
            true,
            "Mask Hornets and Circuit Bees cannot open doors, but Mask Hornets travel at their multiplayer speed in singleplayer.\n\n" +
            "Disable this if you're using other mods that change the behavior of bees."
        );
        changeNutcrackerBehavior = config.Bind(
            "Entites",
            "Gradually Faster Nutcracker",
            true,
            "Nutcrackers at 2-3 HP will shoot slightly faster. (1.3s for the first shot, 1s for the second shot)\n\n" +
            "Disable this if you're using other mods that change the behavior of Nutcrackers."
        );
        changeMouthDogHealth = config.Bind(
            "Entites",
            "10 HP Eyeless Dogs",
            true,
            "Eyeless Dogs have 10 HP instead of 12.\n\n" +
            "Disable this if you're using other mods that change the behavior of Eyeless Dogs."
        );
        changeJesterTimer = config.Bind(
            "Entites",
            "Old Jester Timer",
            true,
            "Jesters will wait 25-42 seconds to begin cranking.\n\n" +
            "Disable this if you're using other mods that change the timer of Jesters."
        );
        changeStormyTimers = config.Bind(
            "Weather",
            "Rebalanced Stormy",
            true,
            "Increase the maximum duration between lightning strikes slightly (by 25%) and doubles the minimum duration for held items being struck.\n\n" +
            "Disable this if you're using other mods that change the behavior of Stormy Weather."
        );
    }
}
