using System;

namespace SocialNetwork
{
    public class Post : IPost
    {
        public Post(string username, string message, DateTime writtenAt)
        {
            Username = username;
            Message = message;
            WrittenAt = writtenAt;
        }

        public string Username { get; set; }
        public string Message { get; }
        public DateTime WrittenAt { get; }
    }
}