using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace NukeLock.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Lock : ICommand
    {
        public string Command { get; } = "nukelock";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Switches the Warhead between cancelable and uncancelable";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender != null && !sender.CheckPermission("nl.nukelock"))
            {
                response = "You need the 'nl.nukelock' permission to use this Command!";
                return false;
            }

            if(Warhead.IsLocked) // Cancelable
            {
                response = "The Nuke is now Cancelable";
                Warhead.IsLocked = false;
                return true;
            } else // Uncancelable
            {
                response = "The Nuke is now UNCANCELABLE";
                Warhead.IsLocked = true;
                return true;
            }
        }
    }
}
