using System;

namespace SocialNetwork.Model.Post
{
    public class Post
    {
        public Post(string username, string message, DateTime writtenAt)
        {
            Username = username;
            Message = message;
            WrittenAt = writtenAt;
        }

        public string Username { get; }
        public string Message { get; }
        public DateTime WrittenAt { get; }
    }
}