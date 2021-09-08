using Exiled.API.Interfaces;
using System.ComponentModel;

namespace NukeLock
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the Warhead be uncancelable at the start of the Round?")]
        public bool WarheadCancelable { get; set; } = false;

        [Description("How long should the Hint be displayed wgeb a player tries to disable the Nuke while uncancelable? (-1 = Disabled)")]
        public int HintTime { get; set; } = 3;

        [Description("What hint should be displayed when a player tries to disable the nuke while uncancelable?")]
        public string HintMessage { get; set; } = "<color=red>This Nuke cannot be disabled</color>";
    }
}
