using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace NukeLock
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug messages be shown?")]
        public bool Debug { get; set; } = false;

        [Description("Should the Warhead be auto armed at the start of the Round?")]
        public bool WarheadAutoArmed { get; set; } = true;

        [Description("After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled)")]
        public int AutoNuke { get; set; } = 900;

        [Description("After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated")]
        public int AutoNukePermaBroadcastTimer { get; set; } = 30;
        public string AutoNukePermaBroadcastMessage { get; set; } = "<color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>";

        [Description("Should the Warhead be uncancelable at the start of the Round?")]
        public bool WarheadCancelable { get; set; } = false;

        [Description("How long should the Hint be displayed when a player tries to disable the Nuke while it can't be stopped? (-1 = Disabled)")]
        public int HintTime { get; set; } = 3;

        [Description("What hint should be displayed when a player tries to disable the nuke while it can't be stopped?")]
        public string HintMessage { get; set; } = "<color=red>This Nuke cannot be disabled</color>";

        [Description("How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled)")]
        public ushort DetonationBroadcastTime { get; set; } = 3;

        [Description("What broadcast should be broadcasted when the AutoNuke activates?")]
        public string DetonationBroadcastMessage { get; set; } = "<color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>";

        [Description("After what time should a cassie message be broadcasted?")]
        public Dictionary<int, string> CassieWarnings { get; set; } = new Dictionary<int, string>
        {
            { 600, "Attention, all personnel, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 10 Minutes" },
            { 300, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 5 Minutes" },
            { 120, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 2 Minutes" },
            { 30, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 30 Seconds" }
        };
    }
}
