﻿using Exiled.API.Features;
using MEC;
using NukeLock.Events;
using System;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace NukeLock
{
    public class NukeLock : Plugin<Config>
    {
        public override string Author => "Marco15453";
        public override string Name => "NukeLock";
        public override Version Version => new Version(1, 11, 0);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public CoroutineHandle nukeCoroutine;
        public CoroutineHandle radiationCoroutine;
        public CoroutineHandle detonationCoroutine;

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
            Server.RestartingRound += serverHandler.OnRestartingRound;

            // Warhead
            Warhead.Starting += warheadHandler.OnStarting;
            Warhead.Stopping += warheadHandler.OnStopping;
            Warhead.Detonated += warheadHandler.OnDetonated;
        }

        private void UnregisterEvents()
        {
            // Server
            Server.RoundStarted -= serverHandler.OnRoundStarted;
            Server.WaitingForPlayers -= serverHandler.OnWaitingForPlayers;
            Server.RestartingRound -= serverHandler.OnRestartingRound;

            // Warhead
            Warhead.Starting -= warheadHandler.OnStarting;
            Warhead.Stopping -= warheadHandler.OnStopping;
            Warhead.Detonated -= warheadHandler.OnDetonated;

            warheadHandler = null;
            serverHandler = null;
        }
    }
}
