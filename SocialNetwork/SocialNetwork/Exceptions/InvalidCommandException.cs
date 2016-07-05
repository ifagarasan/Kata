using System;

namespace SocialNetwork.Exceptions
{
    public class InvalidCommandException: Exception
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}