using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace NukeLock.Events
{
    internal sealed class ServerHandler
    {
        private CoroutineHandle nukeCoroutine;
        public void onRoundStarted()
        {
            NukeLock.Instance.NukeStatus = NukeLock.Instance.Config.WarheadCancelable;
            Warhead.LeverStatus = NukeLock.Instance.Config.WarheadAutoArmed;

            if (nukeCoroutine != null && nukeCoroutine.IsRunning) Timing.KillCoroutines(nukeCoroutine);
            if(NukeLock.Instance.Config.AutoNuke > 0) nukeCoroutine = Timing.RunCoroutine(AutoNuke());
        }

        private IEnumerator<float> AutoNuke()
        {
            int time = NukeLock.Instance.Config.AutoNuke;

            while(time > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (time <= NukeLock.Instance.Config.AutoNukePermaBroadcastTimer)
                    Map.Broadcast(1, NukeLock.Instance.Config.AutoNukePermaBroadcastMessage.Replace("%COUNTDOWN%", time.ToString()), Broadcast.BroadcastFlags.Normal, true);

                if(NukeLock.Instance.Config.CassieWarnings.Count > 0)
                    foreach (var cassie in NukeLock.Instance.Config.CassieWarnings)
                    {
                        if (cassie.Key == time) Cassie.Message(cassie.Value);
                    }
                time -= 1;
            }

            yield return Timing.WaitForSeconds(1f);

            if(time <= 0)
            {
                if (NukeLock.Instance.Config.DetonationBroadcastTime > 0)
                    Map.Broadcast(NukeLock.Instance.Config.DetonationBroadcastTime, NukeLock.Instance.Config.DetonationBroadcastMessage, Broadcast.BroadcastFlags.Normal, true);
                NukeLock.Instance.NukeStatus = true;
                Warhead.LeverStatus = true;
                Warhead.Start();
            }
        }
    }
}
