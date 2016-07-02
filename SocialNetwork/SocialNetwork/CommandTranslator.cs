using System;

namespace SocialNetwork
{
    public class CommandTranslator : ICommandTranslator
    {
        public ICommand Translate(string command)
        {
            var splitIndex = command.IndexOf("->", StringComparison.Ordinal);

            if (splitIndex != -1)
                return new PostCommand(command.Substring(0, splitIndex-1), command.Substring(splitIndex + 3));

            return new DisplayCommand(command);
        }
    }
}