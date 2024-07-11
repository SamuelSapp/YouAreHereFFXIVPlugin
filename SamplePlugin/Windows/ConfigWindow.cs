using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace YouAreHere.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    public ConfigWindow(Plugin plugin) : base("You Are Here Config###YAHConfig")
    {
        Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoScrollWithMouse;

        Size = new Vector2(232, 115);
        SizeCondition = ImGuiCond.Always;

        Configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void PreDraw()
    {
        
    }

    public override void Draw()
    {
        // can't ref a property, so use a local copy
        var showPlayerPos = Configuration.ShowPlayerPositionWindow;
        if (ImGui.Checkbox("Show Player Position", ref showPlayerPos))
        {
            Configuration.ShowPlayerPositionWindow = showPlayerPos;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            Configuration.Save();
        }

        var showTargetPos = Configuration.ShowTargetPositionWindow;
        if (ImGui.Checkbox("Show Target Position", ref showTargetPos))
        {
            Configuration.ShowTargetPositionWindow = showTargetPos;
            Configuration.Save();
        }

        var isHideInstance = Configuration.HideOutsideInstance;
        if (ImGui.Checkbox("Hide Outside Instance", ref isHideInstance))
        {
            Configuration.HideOutsideInstance = isHideInstance;
            Configuration.Save();
        }

        
    }
}
