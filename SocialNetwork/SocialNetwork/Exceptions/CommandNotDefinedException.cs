using System;

namespace SocialNetwork.Exceptions
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