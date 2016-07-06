using System;

namespace SocialNetwork.Model.Command.Exceptions
{
    public class CommandTypeNotDefinedException: Exception
    {
        public CommandTypeNotDefinedException()
        {
        }

        public CommandTypeNotDefinedException(string message) : base(message)
        {
        }
    }
}