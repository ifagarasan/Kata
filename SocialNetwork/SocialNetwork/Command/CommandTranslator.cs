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
                return new DisplayUserTimeline(command);

            if (split[1].Equals("->"))
                return new PostMessage(split[0], command.Substring(command.IndexOf("->", StringComparison.InvariantCulture) + 3));

            throw new InvalidCommandException($"Command '{command}' is not supported");
        }
    }
}