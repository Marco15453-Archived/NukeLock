using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace NukeLock.Events
{
    internal sealed class WarheadHandler
    {
        public NukeLock plugin;
        public WarheadHandler(NukeLock plugin) => this.plugin = plugin;

        public void onStopping(StoppingEventArgs ev)
        {
            if (!Warhead.IsLocked) return;

            Log.Debug($"{ev.Player.Nickname} tried to stop warhead!", plugin.Config.Debug);

            if (plugin.Config.HintTime > 0) 
                ev.Player.ShowHint(plugin.Config.HintMessage, plugin.Config.HintTime);

            ev.IsAllowed = false;
        }
    }
}
