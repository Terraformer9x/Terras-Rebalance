using BepInEx;
using TerrasRebalance.Patches;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System.Dynamic;
using BepInEx.Configuration;

namespace TerrasRebalance;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
    public static Plugin Instance;
    
    private void Awake()
    {
        Instance ??= this;

        Configuration.Bind(base.Config);

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        if (Configuration.changeBeeBehavior.Value)
        {
            Logger.LogInfo("Applying Bees Patch");
            harmony.PatchAll(typeof(CircuitBeesPatch));
            harmony.PatchAll(typeof(ButlerBeesPatch));
            Logger.LogInfo("Bees Patched");
        }
        else Logger.LogInfo("Skipping Bees Patch");

        if (Configuration.changeButlerHealth.Value)
        {
            Logger.LogInfo("Applying Butler Patch");
            harmony.PatchAll(typeof(ButlerPatch));
            Logger.LogInfo("Butler Patched");
        }
        else Logger.LogInfo("Skipping Butler Patch");

        if (Configuration.changeJesterTimer.Value)
        {
            Logger.LogInfo("Applying Jester Patch");
            harmony.PatchAll(typeof(JesterPatch));
            Logger.LogInfo("Jester Patched");
        }
        else Logger.LogInfo("Skipping Jester Patch");

        if (Configuration.changeNutcrackerBehavior.Value)
        {
            Logger.LogInfo("Applying Nutcracker Patch");
            harmony.PatchAll(typeof(NutcrackerPatch));
            Logger.LogInfo("Nutcracker Patched");
        }
        else Logger.LogInfo("Skipping Nutcracker Patch");

        if (Configuration.changeShovelWeight.Value || Configuration.changeStopSignWeight.Value || Configuration.changeJetpackPrice.Value)
        {
            Logger.LogInfo("Applying Items Patch");
            harmony.PatchAll(typeof(ItemPatch));
            Logger.LogInfo("Items Patched");
        }
        else Logger.LogInfo("Skipping Items Patch");

        if (Configuration.changeStormyTimers.Value)
        {
            Logger.LogInfo("Applying Stormy Patch");
            harmony.PatchAll(typeof(StormyPatch));
            Logger.LogInfo("Stormy Patched");
        }
        else Logger.LogInfo("Skipping Stormy Patch");
    }

    public static void Log(string msg) => Instance.Logger.LogInfo(msg);
}