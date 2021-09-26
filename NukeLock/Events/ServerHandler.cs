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

        private CoroutineHandle nukeCoroutine;
        public void onRoundStarted()
        {
            if (!plugin.Config.WarheadCancelable) Warhead.IsLocked = true;
            Warhead.LeverStatus = plugin.Config.WarheadAutoArmed;

            if (nukeCoroutine != null && nukeCoroutine.IsRunning) Timing.KillCoroutines(nukeCoroutine);
            if(plugin.Config.AutoNuke > 0) nukeCoroutine = Timing.RunCoroutine(AutoNuke());
        }

        private IEnumerator<float> AutoNuke()
        {
            int time = plugin.Config.AutoNuke;

            while(time > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (time <= plugin.Config.AutoNukePermaBroadcastTimer)
                    Map.Broadcast(1, plugin.Config.AutoNukePermaBroadcastMessage.Replace("%COUNTDOWN%", time.ToString()), Broadcast.BroadcastFlags.Normal, true);

                if(plugin.Config.CassieWarnings.Count > 0)
                    foreach (var cassie in plugin.Config.CassieWarnings)
                    {
                        if (cassie.Key == time) Cassie.Message(cassie.Value);
                    }
                time -= 1;
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
