using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NukeLock.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class NukeArm : ICommand
    {
        public string Command { get; } = "nukearm";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Switches the Warhead between armed and unarmed";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender != null && !sender.CheckPermission("nl.nukearm"))
            {
                response = "You need the 'nl.nukearm' permission to use this Command!";
                return false;
            }

            if(!Warhead.LeverStatus) // Cancelable
            {
                response = "The Nuke is now armed!";
                Warhead.LeverStatus = true;
                return true;
            } else // Uncancelable
            {
                response = "The Nuke is no longer armed!";
                Warhead.LeverStatus = false;
                return true;
            }
        }
    }
}
