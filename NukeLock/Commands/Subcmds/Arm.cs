using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NukeLock.Commands.Subcmds
{
    public class Arm : ICommand
    {
        public string Command { get; } = "arm";
        public string[] Aliases { get; } = { "a" };
        public string Description { get; } = "Arms/Unarms the Alpha Warhead.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("nl.arm"))
            {
                response = "You don't have permission to execute this command. Required permission: nl.arm";
                return false;
            }

            if (!Warhead.LeverStatus)
            {
                Warhead.LeverStatus = true;
                response = "The Alpha Warhead is now armed.";
                return true;
            }

            Warhead.LeverStatus = false;
            response = "The Alpha Warhead is now unarmed.";
            return true;
        }
    }
}
