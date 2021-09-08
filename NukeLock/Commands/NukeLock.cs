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
            Player p = Player.Get((CommandSender)sender);

            if (p != null && !p.CheckPermission("nl.nukelock"))
            {
                response = "You need the 'nl.nukelock' permission to use this Command!";
                return false;
            }

            if(NukeLock.Instance.NukeStatus) // Cancelable
            {
                response = "The Nuke is now Cancelable";
                NukeLock.Instance.NukeStatus = false;
                return true;
            } else // Uncancelable
            {
                response = "The Nuke is now UNCANCELABLE";
                NukeLock.Instance.NukeStatus = true;
                return true;
            }
        }
    }
}
