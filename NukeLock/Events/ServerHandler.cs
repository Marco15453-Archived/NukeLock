using Exiled.Events.EventArgs;

namespace NukeLock.Events
{
    internal sealed class ServerHandler
    {

        public void onRoundStarted()
        {
            NukeLock.Instance.NukeStatus = NukeLock.Instance.Config.WarheadCancelable;
        }
    }
}
