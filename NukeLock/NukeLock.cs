using Exiled.API.Features;
using NukeLock.Events;
using System;
using MEC;

using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace NukeLock
{
    public class NukeLock : Plugin<Config>
    {
        public override string Author => "Marco15453";
        public override string Name => "NukeLock";
        public override Version Version => new Version(1, 5, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 5);

        private WarheadHandler warheadHandler;
        private ServerHandler serverHandler;

        public override void OnEnabled()
        {
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
            warheadHandler = new WarheadHandler(this);
            serverHandler = new ServerHandler(this);

            // Server
            Server.RoundStarted += serverHandler.OnRoundStarted;
            Server.WaitingForPlayers += serverHandler.OnWaitingForPlayers;
            Server.RoundEnded += serverHandler.OnRoundEnded;

            // Warhead
            Warhead.Stopping += warheadHandler.OnStopping;
        }

        private void UnregisterEvents()
        {
            // Server
            Server.RoundStarted -= serverHandler.OnRoundStarted;
            Server.WaitingForPlayers -= serverHandler.OnWaitingForPlayers;
            Server.RoundEnded -= serverHandler.OnRoundEnded;

            // Warhead
            Warhead.Stopping -= warheadHandler.OnStopping;

            warheadHandler = null;
            serverHandler = null;
        }
    }
}
