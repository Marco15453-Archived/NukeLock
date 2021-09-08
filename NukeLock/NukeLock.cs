

using Exiled.API.Features;
using NukeLock.Events;
using System;

namespace NukeLock
{
    public class NukeLock : Plugin<Config>
    {
        internal static NukeLock Instance;

        public override string Author => "Marco15453";
        public override string Name => "NukeLock";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(2, 14, 0);

        public bool NukeStatus = false;


        private WarheadHandler warheadHandler;
        private ServerHandler serverHandler;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            warheadHandler = new WarheadHandler();
            serverHandler = new ServerHandler();

            // Server
            Exiled.Events.Handlers.Server.RoundStarted += serverHandler.onRoundStarted;

            // Warhead
            Exiled.Events.Handlers.Warhead.Stopping += warheadHandler.onStopping;
        }

        private void UnregisterEvents()
        {
            // Server
            Exiled.Events.Handlers.Server.RoundStarted -= serverHandler.onRoundStarted;

            // Warhead
            Exiled.Events.Handlers.Warhead.Stopping -= warheadHandler.onStopping;

            warheadHandler = null;
            serverHandler = null;
        }
    }
}
