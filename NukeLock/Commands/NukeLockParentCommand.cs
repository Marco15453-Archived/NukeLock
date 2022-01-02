using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using NukeLock.Commands.Subcmds;
using System;

namespace NukeLock.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class NukeLockParentCommand : ParentCommand
    {
        public NukeLockParentCommand() => LoadGeneratedCommands();

        public override string Command { get; } = "nukelock";
        public override string[] Aliases { get; } = { "nl" };
        public override string Description { get; } = "Parent command for NukeLock";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Arm());
            RegisterCommand(new Lock());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            response = "\nPlease enter a valid subcommand:\n";
            foreach (var command in AllCommands)
                if (player.CheckPermission($"nl.{command.Command}"))
                    response += $"- {command.Command} ({string.Join(", ", Aliases)})\n";
            return false;
        }
    }
}
