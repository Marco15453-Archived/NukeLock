using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NukeLock.Events
{
    internal sealed class WarheadHandler
    {
        public NukeLock plugin;
        public WarheadHandler(NukeLock plugin) => this.plugin = plugin;

        public void OnStarting(StartingEventArgs ev)
        {
            if (plugin.Config.WarheadDetonationTimer)
                plugin.detonationCoroutine = Timing.RunCoroutine(DetonationTimer());
        }

        public void OnStopping(StoppingEventArgs ev)
        {
            if (!Warhead.IsLocked || ev.Player == null) 
                return;

            if (plugin.Config.HintTime > 0)
                ev.Player.ShowHint(plugin.Config.HintMessage, plugin.Config.HintTime);

            if (plugin.Config.WarheadDetonationTimer)
                Timing.KillCoroutines(plugin.detonationCoroutine);

            ev.IsAllowed = false;
        }

        public void OnDetonated()
        {
            if (!string.IsNullOrEmpty(plugin.Config.RadiationWarningMessage))
                Map.Broadcast(5, plugin.Config.RadiationWarningMessage, Broadcast.BroadcastFlags.Normal, true);

            if (plugin.Config.RadiationDelay > 0)
                plugin.radiationCoroutine = Timing.RunCoroutine(Radiation());
        }

        private IEnumerator<float> Radiation()
        {
            yield return Timing.WaitForSeconds(plugin.Config.RadiationDelay);

            if (!string.IsNullOrEmpty(plugin.Config.RadiationBeginMessage))
                Map.Broadcast(5, plugin.Config.RadiationBeginMessage, Broadcast.BroadcastFlags.Normal, true);

            while (true)
            {
                yield return Timing.WaitForSeconds(plugin.Config.RadiationInterval);

                foreach (Player player in Player.List.Where(x => x.Team != Team.RIP))
                    player.Hurt(plugin.Config.RadiationDeathReason, plugin.Config.RadiationDamage);
            }
        }

        private IEnumerator<float> DetonationTimer()
        {
            while (Warhead.DetonationTimer > 0)
            {
                yield return Timing.WaitForSeconds(1f);

                if (!Warhead.IsInProgress)
                    yield break;

                string message = plugin.Config.WarheadDetonationMessage.Replace("%COUNTDOWN%", Math.Round(Warhead.DetonationTimer, 0).ToString());

                if (Warhead.DetonationTimer <= 1)
                    message = message.Replace("seconds", "second");

                Map.Broadcast(1, message);
            }
        }
    }
}
