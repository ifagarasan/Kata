using System;

namespace SocialNetwork.Exceptions
{
    public class CommandProcessorNotDefinedException: Exception
    {
        public CommandProcessorNotDefinedException()
        {
        }

        public CommandProcessorNotDefinedException(string message) : base(message)
        {
        }
    }
}