using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;

namespace NukeLock.Events
{
    internal sealed class ServerHandler
    {
        public NukeLock plugin;
        public ServerHandler(NukeLock plugin) => this.plugin = plugin;

        private int AutoNukeTime = 0;

        public void OnRoundStarted()
        {
            Warhead.IsLocked = plugin.Config.WarheadCancelable;
            Warhead.LeverStatus = plugin.Config.WarheadAutoArmed;

            if (plugin.Config.AutoNuke > 0)
                plugin.nukeCoroutine = Timing.RunCoroutine(AutoNuke());
        }

        public void OnRestartingRound()
        {
            Timing.KillCoroutines(plugin.nukeCoroutine, plugin.radiationCoroutine, plugin.detonationCoroutine);
        }

        public void OnWaitingForPlayers()
        {
            Timing.KillCoroutines(plugin.nukeCoroutine, plugin.radiationCoroutine, plugin.detonationCoroutine);

            if (plugin.Config.WarheadColor.Red >= 0 || plugin.Config.WarheadColor.Blue >= 0 || plugin.Config.WarheadColor.Green >= 0)
                foreach (Room room in Room.List)
                    if (room != null && room.FlickerableLightController != null)
                        room.FlickerableLightController.WarheadLightColor = new UnityEngine.Color(plugin.Config.WarheadColor.Red / 255, plugin.Config.WarheadColor.Green / 255, plugin.Config.WarheadColor.Blue / 255);
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (plugin.Config.WarheadDisablesTeamRespawn && Warhead.IsDetonated)
                ev.IsAllowed = false;
        }

        private IEnumerator<float> AutoNuke()
        {
            AutoNukeTime = plugin.Config.AutoNuke;

            while (AutoNukeTime > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (Warhead.IsDetonated)
                    yield break;

                if (AutoNukeTime <= plugin.Config.AutoNukePermaBroadcastTimer)
                {
                    string message = plugin.Config.AutoNukePermaBroadcastMessage.Replace("%COUNTDOWN%", AutoNukeTime.ToString());
                    if (AutoNukeTime <= 1)
                        message = message.Replace("seconds", "second");
                    Map.Broadcast(1, message, Broadcast.BroadcastFlags.Normal, true);
                }

                if (plugin.Config.CassieWarnings.Count > 0 && plugin.Config.CassieWarnings != null)
                {
                    foreach (var cassie in plugin.Config.CassieWarnings)
                    {
                        float cassie_duration = Cassie.CalculateDuration(cassie.Value);
                        double annoucement = cassie.Key + Math.Round(cassie_duration, 0);
                        if (annoucement == AutoNukeTime)
                            Cassie.Message(cassie.Value);
                    }
                }
                AutoNukeTime -= 1;
            }

            yield return Timing.WaitForSeconds(1f);

            if (plugin.Config.DetonationBroadcastTime > 0)
                Map.Broadcast(plugin.Config.DetonationBroadcastTime, plugin.Config.DetonationBroadcastMessage, Broadcast.BroadcastFlags.Normal, true);
            Warhead.LeverStatus = true;
            Warhead.IsLocked = true;
            Warhead.Start();
        }
    }
}
