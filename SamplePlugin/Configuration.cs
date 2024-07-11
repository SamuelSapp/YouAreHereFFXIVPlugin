using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace YouAreHere;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public bool ShowPlayerPositionWindow { get; set; } = true;
    public bool ShowTargetPositionWindow { get; set; } = true;
    public bool HideOutsideInstance { get; set; } = true;

    // the below exist just to make saving less cumbersome
    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
