using BepInEx;
using TerrasRebalance.Patches;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System.Dynamic;

namespace TerrasRebalance;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
    public static Plugin Instance;
    
    private void Awake()
    {
        Instance ??= this;

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        Logger.LogInfo("Applying Bees Patch");
        harmony.PatchAll(typeof(CircuitBeesPatch));
        harmony.PatchAll(typeof(ButlerBeesPatch));
        Logger.LogInfo("Bees Patched");

        Logger.LogInfo("Applying Butler Patch");
        harmony.PatchAll(typeof(ButlerPatch));
        Logger.LogInfo("Butler Patched");

        Logger.LogInfo("Applying Jester Patch");
        harmony.PatchAll(typeof(JesterPatch));
        Logger.LogInfo("Jester Patched");

        Logger.LogInfo("Applying Nutcracker Patch");
        harmony.PatchAll(typeof(NutcrackerPatch));
        Logger.LogInfo("Nutcracker Patched");

        Logger.LogInfo("Applying Shovel Patch");
        harmony.PatchAll(typeof(ShovelPatch));
        Logger.LogInfo("Shovel Patched");

        Logger.LogInfo("Applying Stormy Patch");
        harmony.PatchAll(typeof(StormyPatch));
        Logger.LogInfo("Stormy Patched");
    }

    public static void Log(string msg) => Instance.Logger.LogInfo(msg);
}