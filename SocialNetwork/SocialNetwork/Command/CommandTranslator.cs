using System;
using System.Diagnostics;
using SocialNetwork.Exceptions;

namespace SocialNetwork.Command
{
    public class CommandTranslator : ICommandTranslator
    {
        public ICommand Translate(string command)
        {
            if (command.Equals("exit"))
                return new Exit();

            var split = command.Split(' ');
            if (split.Length == 1)
                return new DisplayTimeline(command);

            if (split.Length == 2 && split[1].Equals("wall"))
                return new DisplayWall(split[0]);

            if (split.Length == 3 && split[1].Equals("follows"))
                return new Follow(split[0], split[2]);

            if (split[1].Equals("->"))
                return new PostMessage(split[0], command.Substring(command.IndexOf("->", StringComparison.InvariantCulture) + 3));

            throw new InvalidCommandException($"Command '{command}' is not supported");
        }
    }
}