using System;

namespace SocialNetwork.Exceptions
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