using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using Dalamud.Bindings.ImGui;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Conditions;

namespace YouAreHere.Windows;

public class MainWindow : Window, IDisposable
{
    private Plugin Plugin;
    private string xText = string.Empty;
    private string yText = string.Empty;
    private string zText = string.Empty;
    private Vector2 windowSize = new Vector2(50f, 53f);


    public MainWindow(Plugin plugin)
        : base("Player Position Window##YAHPlayerPositionWindow", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.NoDecoration)
    {
        this.DisableWindowSounds = true;
        this.RespectCloseHotkey = false;

        this.Position = new(0, 0);

        this.PositionCondition = ImGuiCond.Always;
        this.SizeCondition = ImGuiCond.Always;

        this.Size = windowSize;

        this.IsOpen = true;
        Plugin = plugin;
    }

    public void Dispose() { }

    private string FormatPOSValue(float value)
    {
        string output = $"{value,8:##0.00}";
        return output;
    }

    public override bool DrawConditions()
    {
        var actor = Plugin.ClientState.LocalPlayer;
        if (actor == null || !Plugin.Configuration.ShowPlayerPositionWindow || (Plugin.Configuration.HideOutsideInstance && !Plugin.Condition[ConditionFlag.BoundByDuty]))
        {
            return false;
        }
        else return true;
    }

    public override void PreDraw()
    {
        var actor = Plugin.ClientState.LocalPlayer;

        if (actor == null) return;

        xText = FormatPOSValue(actor.Position.X);
        yText = FormatPOSValue(actor.Position.Y);
        zText = FormatPOSValue(actor.Position.Z);


        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0, 0));
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(0, 0));
        ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 0));
    }

    public override void Draw()
    {

        ImGui.Text(xText);
        ImGui.Text(zText);
        ImGui.Text(yText);
    }

    public override void PostDraw()
    {
        ImGui.PopStyleVar(3);
    }
}

