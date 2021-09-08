using Exiled.Events.EventArgs;

namespace NukeLock.Events
{
    internal sealed class WarheadHandler
    {

        public void onStopping(StoppingEventArgs ev)
        {
            if (!NukeLock.Instance.NukeStatus) return;

            if (NukeLock.Instance.Config.HintTime > 0) ev.Player.ShowHint(NukeLock.Instance.Config.HintMessage, NukeLock.Instance.Config.HintTime);

            ev.IsAllowed = false;
        }
    }
}
