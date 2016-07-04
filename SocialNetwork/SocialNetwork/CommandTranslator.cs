using System;
using SocialNetwork.Command;

namespace SocialNetwork
{
    public class CommandTranslator : ICommandTranslator
    {
        public ICommand Translate(string command)
        {
            if (command.Equals("exit"))
                return new Exit();

            var splitIndex = command.IndexOf("->", StringComparison.Ordinal);

            if (splitIndex != -1)
                return new PostMessage(command.Substring(0, splitIndex-1), command.Substring(splitIndex + 3));

            return new DisplayUserPosts(command);
        }
    }
}