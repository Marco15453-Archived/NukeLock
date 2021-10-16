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

        int AutoNukeTime = 0;

        private CoroutineHandle nukeCoroutine;
        public void OnRoundStarted()
        {
            Log.Debug($"Round Started! Killing Coroutines", plugin.Config.Debug);
            if (!plugin.Config.WarheadCancelable) Warhead.IsLocked = true;
            Warhead.LeverStatus = plugin.Config.WarheadAutoArmed;
            Timing.KillCoroutines(nukeCoroutine);
            AutoNukeTime = plugin.Config.AutoNuke;

            if(plugin.Config.AutoNuke > 0) nukeCoroutine = Timing.RunCoroutine(AutoNuke());
        }

        public void OnWaitingForPlayers()
        {
            Log.Debug($"Waiting For Players, Killing Coroutines", plugin.Config.Debug);
            AutoNukeTime = plugin.Config.AutoNuke;
            Timing.KillCoroutines(nukeCoroutine);
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Log.Debug($"Round Ended! Killing Coroutines", plugin.Config.Debug);
            Timing.KillCoroutines(nukeCoroutine);
        }

        private IEnumerator<float> AutoNuke()
        {
            Log.Debug($"Warhead Auto Nuke is now ready and will engage in {AutoNukeTime} Seconds", plugin.Config.Debug);

            while(AutoNukeTime > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (AutoNukeTime <= plugin.Config.AutoNukePermaBroadcastTimer)
                    Map.Broadcast(1, plugin.Config.AutoNukePermaBroadcastMessage.Replace("%COUNTDOWN%", AutoNukeTime.ToString()), Broadcast.BroadcastFlags.Normal, true);

                if(plugin.Config.CassieWarnings.Count > 0 && plugin.Config.CassieWarnings != null)
                    foreach (var cassie in plugin.Config.CassieWarnings)
                    {
                        if (cassie.Key == AutoNukeTime) Cassie.Message(cassie.Value);
                        Log.Debug($"Cassie message at {cassie.Key} will now play", plugin.Config.Debug);
                    }
                AutoNukeTime -= 1;
            }

            yield return Timing.WaitForSeconds(1f);

            Log.Debug($"Warhead Auto Nuke is now started.", plugin.Config.Debug);

            if (plugin.Config.DetonationBroadcastTime > 0)
                Map.Broadcast(plugin.Config.DetonationBroadcastTime, plugin.Config.DetonationBroadcastMessage, Broadcast.BroadcastFlags.Normal, true);
            Warhead.LeverStatus = true;
            Warhead.IsLocked = true;
            Warhead.Start();
        }
    }
}
