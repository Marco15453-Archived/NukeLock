using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace NukeLock
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the Warhead be armed at the start of the Round?")]
        public bool WarheadAutoArmed { get; set; } = true;

        [Description("Should the Warhead be locked at the start of the Round?")]
        public bool WarheadCancelable { get; set; } = false;

        [Description("Death Message when the player gets killed by Radiation.")]
        public string RadiationDeathReason { get; set; } = "Died by Radiation";

        [Description("After which delay should radiation start when the warhead detonated. (-1 = Disabled)")]
        public float RadiationDelay { get; set; } = 120f;

        [Description("Message to be shown when the Warhead Detonated. (Empty = Disabled)")]
        public string RadiationWarningMessage { get; set; } = "<color=red>The Alpha Warhead has been detonated, Radiation will occur in 2 Minutes</color>";

        [Description("Message to be shown when the Radiation has occured. (Empty = Disabled)")]
        public string RadiationBeginMessage { get; set; } = "<color=red>Radiation has now reached the Surface Zone</color>";

        [Description("The Interval that the radiation_damage will be dealth to all players after the warhead detonates.")]
        public int RadiationInterval { get; set; } = 5;

        [Description("The Damage dealth to players after each radiation_interval")]
        public float RadiationDamage { get; set; } = 2;

        [Description("After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled)")]
        public int AutoNuke { get; set; } = 900;

        [Description("After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated")]
        public int AutoNukePermaBroadcastTimer { get; set; } = 30;
        public string AutoNukePermaBroadcastMessage { get; set; } = "<color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>";

        [Description("How long should the Hint be displayed when a player tries to disable the Nuke while it can't be stopped? (-1 = Disabled)")]
        public int HintTime { get; set; } = 3;

        [Description("What hint should be displayed when a player tries to disable the nuke while it can't be stopped?")]
        public string HintMessage { get; set; } = "<color=red>This Nuke cannot be disabled</color>";

        [Description("How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled)")]
        public ushort DetonationBroadcastTime { get; set; } = 3;

        [Description("What broadcast should be broadcasted when the AutoNuke activates?")]
        public string DetonationBroadcastMessage { get; set; } = "<color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>";

        [Description("Whether or not a broadcast will be shown to all players to tell how many seconds are remaining until the warhead explodes.")]
        public bool WarheadDetonationTimer { get; set; } = true;

        [Description("Message to be shown to tell players how many seconds are remaining until the warhead explodes. %COUNTDOWN% will be replaced with the seconds until the warhead detonates")]
        public string WarheadDetonationMessage { get; set; } = "<color=red>Alpha Warhead detonates in T-Minus</color> <color=orange>%COUNTDOWN% seconds</color>";

        [Description("After what time should a cassie message be broadcasted? (Empty = Disabled)")]
        public Dictionary<int, string> CassieWarnings { get; set; } = new Dictionary<int, string>
        {
            { 600, "Attention, all personnel, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 10 Minutes" },
            { 300, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 5 Minutes" },
            { 120, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 2 Minutes" },
            { 30, "Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 30 Seconds" }
        };
    }
}
