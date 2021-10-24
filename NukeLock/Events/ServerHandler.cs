using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace NukeLock.Events
{
    internal sealed class ServerHandler
    {
        public NukeLock plugin;
        public ServerHandler(NukeLock plugin) => this.plugin = plugin;

        private int AutoNukeTime = 0;

        private CoroutineHandle nukeCoroutine;
        public void OnRoundStarted()
        {
            if (!plugin.Config.WarheadCancelable) Warhead.IsLocked = true;
            Warhead.LeverStatus = plugin.Config.WarheadAutoArmed;
            Timing.KillCoroutines(nukeCoroutine);

            if(plugin.Config.AutoNuke > 0)
            {
                AutoNukeTime = plugin.Config.AutoNuke;
                nukeCoroutine = Timing.RunCoroutine(AutoNuke());
            }
        }

        public void OnWaitingForPlayers()
        {
            if (plugin.Config.AutoNuke > 0) AutoNukeTime = plugin.Config.AutoNuke;
            Timing.KillCoroutines(nukeCoroutine);
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (plugin.Config.AutoNuke > 0) AutoNukeTime = plugin.Config.AutoNuke;
            Timing.KillCoroutines(nukeCoroutine);
        }

        private IEnumerator<float> AutoNuke()
        {
            AutoNukeTime = plugin.Config.AutoNuke;

            while(AutoNukeTime > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (AutoNukeTime <= plugin.Config.AutoNukePermaBroadcastTimer)
                    Map.Broadcast(1, plugin.Config.AutoNukePermaBroadcastMessage.Replace("%COUNTDOWN%", AutoNukeTime.ToString()), Broadcast.BroadcastFlags.Normal, true);

                if(plugin.Config.CassieWarnings.Count > 0 && plugin.Config.CassieWarnings != null)
                    foreach (var cassie in plugin.Config.CassieWarnings)
                        if (cassie.Key == AutoNukeTime) Cassie.Message(cassie.Value);
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
