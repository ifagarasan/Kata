using System;

namespace SocialNetwork.Model.Command.Exceptions
{
    public class CommandNotDefinedException: Exception
    {
        public CommandNotDefinedException()
        {
        }

        public CommandNotDefinedException(string message) : base(message)
        {
        }
    }
}